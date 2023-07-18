using AutoMapper;
using MarketManager.Application.Common.DTOs.ExpiredProductDtos;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.ExpiredProducts.Queries.GetAllExpiredProducts
{
    public class GetAllExpiredProductsQuery : IRequest<List<ExpiredProductGetDto>>
    {
    }

    public class GetAllExpiredProductsQueryHandler : IRequestHandler<GetAllExpiredProductsQuery, List<ExpiredProductGetDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllExpiredProductsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ExpiredProductGetDto>> Handle(GetAllExpiredProductsQuery request, CancellationToken cancellationToken)
        {
            List<ExpiredProduct> expiredProducts = await _context.ExpiredProducts.ToListAsync(cancellationToken);
            List<ExpiredProductGetDto> resExpiredProducts = _mapper.Map<List<ExpiredProductGetDto>>(expiredProducts);
            return resExpiredProducts;
        }
    }
}
