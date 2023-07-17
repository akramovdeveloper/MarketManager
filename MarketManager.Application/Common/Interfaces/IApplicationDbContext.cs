using MarketManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.Common.Interfaces;
public interface IApplicationDbContext
{

    public DbSet<User> Users { get; }

}
