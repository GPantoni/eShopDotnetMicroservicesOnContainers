using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { set; get; }
    public DbSet<Product> Products { set; get; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        //Category
        mb.Entity<Category>().HasKey(c => c.Id);
        mb.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();
        mb.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        //Product
        mb.Entity<Product>().HasKey(p => p.Id);
        mb.Entity<Product>().Property(p => p.Name).HasMaxLength(100).IsRequired();
        mb.Entity<Product>().Property(p => p.Description).HasMaxLength(255).IsRequired();
        mb.Entity<Product>().Property(p => p.ImageUrl).HasMaxLength(255).IsRequired();
        mb.Entity<Product>().Property(p => p.Price).HasPrecision(12, 2).IsRequired();

        //Seed Data
        mb.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Material Escolar" },
            new Category { Id = 2, Name = "Acessórios" }
        );
    }
}