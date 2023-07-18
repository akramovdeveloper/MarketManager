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
