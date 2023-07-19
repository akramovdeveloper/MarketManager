using AutoMapper;
using MarketManager.Application.UseCases.Orders.Commands.CreateOrder;
using MarketManager.Application.UseCases.Orders.Commands.DeleteOrder;
using MarketManager.Application.UseCases.Orders.Commands.UpdateOrder;
using MarketManager.Application.UseCases.Orders.Queries.GetOrder;
using MarketManager.Domain.Entities;
using static MarketManager.Application.UseCases.Orders.Queries.GetAllOrders.GetallOrderCommmandHandler;

namespace MarketManager.Application.Common.Mappings;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        OrderMappings();
        OrderWithCart();
    }

    private void OrderWithCart()
    {
        CreateMap<CreateOrderCommand, Order>();
        CreateMap<UpdateOrderCommand, Order>();
        CreateMap<DeleteOrderCommand, Order>();
    }

    private void OrderMappings()
    {
        CreateMap< Order, GetOrderByIdResponse>();
        CreateMap< Order, GetAllOrderQueryResponse>();
    }
}
