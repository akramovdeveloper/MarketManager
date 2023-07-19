using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Orders.ResponseModels;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Orders.Queries.GetOrder;

public record GetOrderQuery(Guid Id) : IRequest<OrderWithCarts>;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderWithCarts>
{
    IApplicationDbContext _dbContext;
    IMapper _mapper;

    public GetOrderQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public async Task<OrderWithCarts> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        Order order = FilterIfOrderExsists(request.Id);

        return _mapper.Map<OrderWithCarts>(order);
    }

    private Order FilterIfOrderExsists(Guid id)
        => _dbContext.Orders
            .Include(x => x.Carts)
            .FirstOrDefault(x => x.Id == id)
                 ?? throw new NotFoundException(
                        " There is no order with this Id. ");


}
