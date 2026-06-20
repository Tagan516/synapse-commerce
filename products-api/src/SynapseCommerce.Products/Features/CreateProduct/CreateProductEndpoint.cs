using SynapseCommerce.Products.Domain;
using SynapseCommerce.Shared;

namespace SynapseCommerce.products.Endpoints;

public class CreateProductEndpoint (ProductsDbContext db) : IEndpoint
{
    public void MapRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request) =>
        {
            var product = new Product
            {
                Id = new Guid(),
                SKU = request.SKU,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                IsActive = false,
                IsAvailable = false,
                ImageUrl = "",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return Results.Created($"/products/{product.Id}", product);
        });
    }
}