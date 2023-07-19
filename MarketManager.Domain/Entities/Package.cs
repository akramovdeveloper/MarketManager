namespace MarketManager.Domain.Entities;

public class Package : BaseAuditableEntity
{
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
    public double IncomingCount { get; set; }
    public double ExistCount { get; set; }
    public Guid SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; }
    public double IncomingPrice { get; set; }
    public double SalePrice { get; set; }

    public DateTime IncomingDate { get; set; }
}
