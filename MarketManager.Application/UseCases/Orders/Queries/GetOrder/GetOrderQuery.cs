using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Carts.ResponseModels;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static MarketManager.Application.UseCases.Orders.Queries.GetAllOrders.GetallOrderCommmandHandler;

namespace MarketManager.Application.UseCases.Orders.Queries.GetOrder;

public record GetOrderQuery(Guid Id) : IRequest<GetOrderByIdResponse>;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, GetOrderByIdResponse>
{
    IApplicationDbContext _dbContext;
    IMapper _mapper;

    public GetOrderQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public async Task<GetOrderByIdResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        Order order = FilterIfOrderExsists(request.Id);

        return _mapper.Map<GetOrderByIdResponse>(order);
    }

    private Order FilterIfOrderExsists(Guid id)
        => _dbContext.Orders
            .Include(x => x.Carts)
            .FirstOrDefault(x => x.Id == id)
                 ?? throw new NotFoundException(
                        " There is no order with this Id. ");


}

public class GetOrderByIdResponse : GetAllOrderQueryResponse
{
    public ICollection<CartDto> Cards { get; set; }
}
