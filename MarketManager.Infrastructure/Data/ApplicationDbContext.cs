using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Infrastructure.Data;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
}
