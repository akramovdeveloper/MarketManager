using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.Common.Interfaces;
public interface IApplicationDbContext
{

    public DbSet<User> Users { get; }
    public DbSet<Client> Clients { get; }   
    public DbSet<ExpiredProduct> ExpiredProducts { get; }
    public DbSet<Role> Roles { get; }
    public DbSet<Permission> Permissions { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
