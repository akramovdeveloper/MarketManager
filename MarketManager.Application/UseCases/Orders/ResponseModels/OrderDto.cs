using MarketManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Orders.ResponseModels
{
    public class OrderDto
    {
        public decimal TotalPrice { get; set; }

        public Guid ClientId { get; set; }
        public decimal CardPriceSum { get; set; }
        public decimal CashPurchaseSum { get; set; }
        public ICollection<Card> Cards { get; set; }

    }
}
