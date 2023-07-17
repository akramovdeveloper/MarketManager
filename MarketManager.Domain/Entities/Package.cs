namespace MarketManager.Domain.Entities;

public class Package : BaseAuditableEntity
{
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }

    public double IncomingCount { get; set; }
    public double Count { get; set; }

    public Guid DistibutorId { get; set; }
    public virtual Distributor Distibutor { get; set; }
    public double IncomingPrice { get; set; }
    public double SalePrice { get; set; }

    public DateTime IncomingDate { get; set; }
}
