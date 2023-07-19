using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Carts.Commands.UpdateCart
{
    public class UpdateCartCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public Guid SoldId { get; set; }
        public double Count { get; set; }
        public double SoldPrice { get; set; }
    }
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateCartCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            Cart? cart = await _context.Carts.FindAsync(request.Id);
            _mapper.Map(cart, request);
            if (cart is null)
                throw new NotFoundException(nameof(Cart), request.Id);
            var package = await _context.Packages.FindAsync(request.PackageId);
            if (package is null) 
                throw new NotFoundException(nameof(Package),request.PackageId);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
