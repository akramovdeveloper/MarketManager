using AutoMapper;
using MarketManager.Application.UseCases.Orders.Commands.CreateOrder;
using MarketManager.Application.UseCases.Orders.Commands.DeleteOrder;
using MarketManager.Application.UseCases.Orders.Commands.UpdateOrder;
using MarketManager.Application.UseCases.Orders.Queries.GetAllOrders;
using MarketManager.Application.UseCases.Orders.ResponseModels;
using MarketManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.Common.Mappings
{
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
            CreateMap<GetAllOrderQuery, OrderDto>();
        }

        private void OrderMappings()
        {
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderWithCarts, Order>().ReverseMap();
        }
    }
}
