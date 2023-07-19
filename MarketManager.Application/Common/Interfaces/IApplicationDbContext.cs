using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.Common.Interfaces;
public interface IApplicationDbContext
{

    DbSet<User> Users { get; }
    DbSet<Client> Clients { get; }
    DbSet<Product> Products { get; }
    DbSet<ExpiredProduct> ExpiredProducts { get; }
    DbSet<Role> Roles { get; }
    DbSet<Permission> Permissions { get; }
    DbSet<Package> Packages { get; }

    DbSet<Order> Orders { get; }
    DbSet<Cart> Carts { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
