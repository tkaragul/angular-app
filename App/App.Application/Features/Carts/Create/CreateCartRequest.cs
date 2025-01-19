using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Carts.Create
{
    public record CreateCartRequest
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public CreateCartRequest(int productId, string name, decimal price, int stockQuantity)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Price = price;
            this.StockQuantity = stockQuantity;
        }
    }
}
