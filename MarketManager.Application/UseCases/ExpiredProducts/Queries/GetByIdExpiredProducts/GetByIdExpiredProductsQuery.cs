using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.ExpiredProducts.Queries
{
    public class GetByIdExpiredProductsQuery : IRequest<ExpiredProductGetDto>
    {
        public Guid Id { get; set; }
    }

    public class GetByIdExpiredProductsQueryHandler : IRequestHandler<GetByIdExpiredProductsQuery, ExpiredProductGetDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetByIdExpiredProductsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<ExpiredProductGetDto> Handle(GetByIdExpiredProductsQuery request, CancellationToken cancellationToken)
        {
            ExpiredProduct? res = _context.ExpiredProducts.FirstOrDefault(x=>x.Id== request.Id);
            if()
        }
    }
}
