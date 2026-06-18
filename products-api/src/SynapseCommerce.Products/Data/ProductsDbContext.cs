using Microsoft.EntityFrameworkCore;
using SynapseCommerce.Products.Domain;

public class ProductsDBContext : DbContext
{
    public ProductsDBContext(DbContextOptions<ProductsDBContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.SKU)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(p => p.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(p => p.Description)
                  .HasMaxLength(500);

            entity.Property(p => p.Price)
                  .HasColumnType("decimal(18,2)");

            entity.Property(p => p.IsActive)
                  .IsRequired();

            entity.Property(p => p.IsAvailable)
                  .IsRequired();

            entity.Property(p => p.ImageUrl)
                  .HasMaxLength(200);

            entity.Property(p => p.CreatedAt)
                  .IsRequired();
                  
            entity.Property(p => p.UpdatedAt)
                  .IsRequired();
        });
    }
}