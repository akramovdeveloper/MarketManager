namespace MarketManager.Domain.Entities
{
    public class Client:BaseAuditableEntity
    {
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
    }
}
