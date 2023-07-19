using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Domain.Entities
{
    public  class Order : BaseAuditableEntity
    {
        public decimal TotalPrice { get; set; }
        public Guid ClientId { get; set; }
        public decimal CardPriceSum { get; set; }
        public decimal CashPurchaseSum  { get; set; }
        public ICollection<Cart> Carts { get; set; }


        public Client Client { get; set; }


    }
}
