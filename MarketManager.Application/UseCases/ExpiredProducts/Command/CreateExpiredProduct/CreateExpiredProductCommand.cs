using AutoMapper;
using MarketManager.Application.Common.Abstraction;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.ExpiredProducts.Command.CreateExpiredProduct
{
    public class CreateExpiredProductCommand : IRequest<CreateExpiredProductResponce>
    {
        public Guid PackageId { get; set; }
        public int Count { get; set; }
        
    }
    public class CreateExpiredProductResponce : ExpiredProductBaseResponce
    {

    }

    public class CreateExpiredProductCommandHandler : IRequestHandler<CreateExpiredProductCommand, CreateExpiredProductResponce>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;
        public CreateExpiredProductCommandHandler(IMapper mapper, IApplicationDbContext context, ICurrentUser currentUser)
        {
            _mapper = mapper;
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<CreateExpiredProductResponce> Handle(CreateExpiredProductCommand request, CancellationToken cancellationToken)
        {
            var expiredProduct = new ExpiredProduct
            {
                Id = Guid.NewGuid(),
                PackageId = request.PackageId,
                Count = request.Count,
                CreatedDate = DateTime.Now,
                CreatedById = _currentUser.Id
            };

            var entity = _context.ExpiredProducts.Add(expiredProduct);
            await _context.SaveChangesAsync();
            CreateExpiredProductResponce res = _mapper.Map<CreateExpiredProductResponce>(entity);
            return res;
        }
    }
}
