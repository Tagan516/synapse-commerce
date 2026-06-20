using SynapseCommerce.Shared;

namespace SynapseCommerce.Products.Features.GetProduct;

public class GetProductEndpoint() : IEndpoint
{
    public void MapRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id:guid}", async (Guid id, ProductsDbContext db) =>
        {
            var product = await db.Products.FindAsync(id);

            if (product is null)
            {
                return Results.NotFound(new { Message = $"Product with ID {id} was not found." });
            }

            return Results.Ok(product);
        })
        .WithTags("Products")
        .WithName("GetProductById");
    }
}