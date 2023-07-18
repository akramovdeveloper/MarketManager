using MarketManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    public DbSet<Distributer> Distributers { get; }
    public DbSet<User> Users { get; }
    public DbSet<ExpiredProduct> ExpiredProducts { get; }
}
