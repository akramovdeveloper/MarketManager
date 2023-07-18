using MarketManager.Application.Common.DTOs.ExpiredProductDtos;
using MediatR;

namespace MarketManager.Application.UseCases.ExpiredProducts.Queries
{
    public class GetByIdExpiredProductsQuery : IRequest<ExpiredProductGetDto>
    {

    }
}
