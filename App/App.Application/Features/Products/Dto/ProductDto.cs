namespace App.Application.Features.Products.Dto
{
    public record ProductDto(int Id, string Name, string Detail, string ImageUrl, decimal Price, int StockQuantity, int CategoryId, string CategoryName);
}