using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MarketManager.Infrastructure.Data;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }

    public DbSet<ExpiredProduct> ExpiredProducts { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Product> Products { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DbSet<Package> Packages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DbSet<ProductType> ProductTypes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public DbSet<Permission> Permissions => throw new NotImplementedException();

    public DbSet<Cart> Carts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
