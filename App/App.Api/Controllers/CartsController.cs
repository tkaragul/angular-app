using App.Application.Features.Products;
using App.Application.Features.Products.Create;
using App.Application.Features.Products.Update;
using App.Application.Features.Products.UpdateStock;
using App.Domain.Entities;
using App.API.Filters;
using Microsoft.AspNetCore.Mvc;
using App.Application.Features.Carts;
using App.Application.Features.Carts.Create;

namespace App.API.Controllers
{
    public class CartsController : CustomBaseController
    {
        private readonly string _clientId;
        private readonly ICartService cartService;
        public CartsController(ICartService cartService)
        {
            this.cartService = cartService;
            if (Request != null && Request.Headers.TryGetValue("Client-ID", out var clientId))
            {
                this._clientId = clientId;
            }
            else
            {
                this._clientId = HttpContext?.Session.GetString("UserID");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await cartService.GetAllListAsync(_clientId));


        [HttpPost]
        public async Task<IActionResult> Create(CreateCartRequest request)
        {
            return CreateActionResult(await cartService.CreateAsync(request, _clientId));
        }
    }
}