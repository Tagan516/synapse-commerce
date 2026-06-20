public record CreateProductRequest
(
    string SKU,
    string Name,
    string Description,
    decimal Price,
    string ImageUrl
);