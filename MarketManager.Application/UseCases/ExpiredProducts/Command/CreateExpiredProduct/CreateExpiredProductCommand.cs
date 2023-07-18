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
        
        public CreateExpiredProductCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<CreateExpiredProductResponce> Handle(CreateExpiredProductCommand request, CancellationToken cancellationToken)
        {
            var expiredProduct = new ExpiredProduct
            {
                Id = Guid.NewGuid(),
                PackageId = request.PackageId,
                Count = request.Count,
                DeletedTime = DateTime.Now,
                CreatedDate = DateTime.Now
            };
        }
    }

}
