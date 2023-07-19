using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Carts.Commands.CreateCart
{
    public class CreateCartCommand : IRequest<Guid>
    {
        public Guid PackageId { get; set; }
        public Guid SoldId { get; set; }
        public double Count { get; set; }
        public double SoldPrice { get; set; }
    }
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateCartCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            Cart cart = _mapper.Map<Cart>(request);
            await _context.Carts.AddAsync(cart, cancellationToken);
            await _context.SaveChangesAsync();
            return cart.Id;
        }
    }
}
