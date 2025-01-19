using App.Application.Features.Carts.Create;
using App.Application.Features.Products.Create;
using App.Application.Features.Products.Dto;
using App.Application.Features.Products.Update;
using App.Application.Features.Products.UpdateStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Carts
{
    public interface ICartService
    {
        Task<ServiceResult<List<CreateCartRequest>>> GetAllListAsync(string clientId);
        Task<ServiceResult> CreateAsync(CreateCartRequest request, string clientId);
        Task<ServiceResult> DeleteAsync(int id, string clientId);
    }
}
