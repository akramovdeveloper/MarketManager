using MarketManager.Application.UseCases.Carts.ResponseModels;
using MarketManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Orders.ResponseModels
{
    public class OrderWithCarts : OrderDto
    {
        public ICollection<CartDto> Cards { get; set; }
    }
}
