namespace MarketManager.Domain.Entities
{
    public class ExpiredProducts
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public virtual Package Packages { get; set; }
        public int Count { get; set; }
        public DateTime DeletedTime { get; set; }
        public Guid UserId { get; set; }
        public virtual User Users { get; set; }
    }
}
