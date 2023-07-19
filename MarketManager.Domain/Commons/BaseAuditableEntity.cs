using MarketManager.Domain.Entities.Identity;

namespace MarketManager.Domain.Entities;

public class BaseAuditableEntity : BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifyDate { get; set; }
    public Guid? CreatedById { get; set; }
    public virtual User? CreatedBy { get; set; }
    public Guid? ModifyById { get; set; }
    public virtual User? ModifyBy { get; set; }
}
