using MarketManager.Domain.Enums;

namespace MarketManager.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ProductCategory Category { get; set; }
}
