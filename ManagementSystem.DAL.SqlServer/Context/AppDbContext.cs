using ManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.DAL.SqlServer.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }  

    public DbSet<RefreshToken> RefreshTokens { get; set; }
}