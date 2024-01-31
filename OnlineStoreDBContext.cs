using Microsoft.EntityFrameworkCore;
using OnlineStore.Model;

namespace OnlineStore;

public class OnlineStoreDbContext : DbContext
{
    public DbSet<Client>? Clients { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=OnlineStore;Username=postgres;Password=qwerty");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Настройка Fluent-API
    }
}