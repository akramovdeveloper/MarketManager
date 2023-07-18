using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Domain.Entities
{
    public class Card : BaseAuditableEntity
    {
        public Guid PackageId { get; set; }
        public Guid SoldId { get; set; }
        public double Count { get; set; }
        public double SoldPrice { get; set; }
    }
}
