using App.Application.Features.Products.Create;
using App.Application.Features.Products.Dto;
using App.Application.Features.Products.Update;
using App.Application.Features.Products.UpdateStock;
using App.Application.Features.Products;
using App.Application;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using App.Application.Contracts.Caching;
using App.Application.Features.Carts;
using App.Application.Features.Carts.Create;
using Microsoft.AspNetCore.Http;
using MySqlX.XDevAPI;

namespace App.Persistence.Services
{
    public class CartService(
        ICacheService cacheService) : ICartService
    {
        private const string cacheKey = "CartCacheKey_";
        
        public async Task<ServiceResult<List<CreateCartRequest>>> GetAllListAsync(string clientId)
        {
            var key = $"{cacheKey}{clientId}";

            var cartAsCached = await cacheService.GetAsync<List<CreateCartRequest>>(key);

            return ServiceResult<List<CreateCartRequest>>.Success(cartAsCached);
        }

        public async Task<ServiceResult> CreateAsync(CreateCartRequest request, string clientId)
        {
            var key = $"{cacheKey}{clientId}";

            var cartAsCached = await cacheService.GetAsync<List<CreateCartRequest>>(key);

            if (cartAsCached is null)
            {
                await cacheService.AddAsync(key, request, TimeSpan.FromDays(1));
                return ServiceResult.Success(HttpStatusCode.Created);
            }

            // Sepette aynı ürün ID'si var mı kontrol et
            CreateCartRequest existingItem = cartAsCached.FirstOrDefault(item => item.ProductId == request.ProductId);
            if (existingItem is not null)
            {
                // Aynı ürün varsa, miktarı artır
                existingItem.StockQuantity += request.StockQuantity;
            }
            else
            {
                // Ürün yoksa, yeni ürünü sepete ekle
                cartAsCached.Add(request);
            }


            // Güncellenmiş sepeti tekrar cache'e ekle
            await cacheService.AddAsync(key, cartAsCached, TimeSpan.FromDays(1));

            return ServiceResult.Success(HttpStatusCode.OK);
        }

        public async Task<ServiceResult> DeleteAsync(int id, string clientId)
        {
            var key = $"{cacheKey}{clientId}";

            // Cache'ten mevcut sepeti al
            var cartAsCached = await cacheService.GetAsync<List<CreateCartRequest>>(key);

            if (cartAsCached == null || !cartAsCached.Any())
            {
                return ServiceResult.Fail("Sepet bulunamadı.", HttpStatusCode.NotFound);
            }

            // Ürün ID'ye göre kontrol et
            var productToRemove = cartAsCached.FirstOrDefault(item => item.ProductId == id);
            if (productToRemove == null)
            {
                return ServiceResult.Fail("Ürün sepette bulunamadı.", HttpStatusCode.NotFound);
            }

            // Ürünü sepetten çıkar
            cartAsCached.Remove(productToRemove);

            // Güncellenmiş sepeti tekrar cache'e ekle
            await cacheService.AddAsync(key, cartAsCached, TimeSpan.FromDays(1));

            return ServiceResult.Success();
        }

        
    }
}
