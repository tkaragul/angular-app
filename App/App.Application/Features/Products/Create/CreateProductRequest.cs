namespace App.Application.Features.Products.Create;

public record CreateProductRequest(string Name, string Detail, string ImageUrl, decimal Price, int Stock, int CategoryId);