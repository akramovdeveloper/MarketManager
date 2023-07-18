using MarketManager.Domain.Entities.Identity;

namespace MarketManager.Application.UseCases.Users.Response;
public class UserResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Role>? Roles { get; set; }


}
