using MarketManager.Domain.Entities.Identity;

namespace MarketManager.Domain.Entities
{
    public class ExpiredProduct : BaseAuditableEntity
    {
       
        public Guid PackageId { get; set; }
        public virtual Package Packages { get; set; }
        public int Count { get; set; }
        public DateTime DeletedTime { get; set; }
    }
}
