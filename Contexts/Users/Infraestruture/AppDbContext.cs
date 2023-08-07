using Microsoft.EntityFrameworkCore;
using Contexts.Users.Domain;

namespace Contexts.Users.Infraestruture;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>(entity => {
            entity.ToTable("users");
        });
    }
    public DbSet<User> Users { get; set; }
}