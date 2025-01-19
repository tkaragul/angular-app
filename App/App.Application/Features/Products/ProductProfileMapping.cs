using App.Application.Extensions;
using App.Application.Features.Products.Create;
using App.Application.Features.Products.Dto;
using App.Application.Features.Products.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Products
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category == null ? "" : src.Category.Name))
                .ReverseMap();
                
            CreateMap<CreateProductRequest, Product>()
                .ForMember(dest => dest.Slug,
                    opt => opt.MapFrom(src => SlugHelper.GenerateSlug(src.Name)));

            CreateMap<UpdateProductRequest, Product>()
                .ForMember(dest => dest.Slug,
                    opt => opt.MapFrom(src => SlugHelper.GenerateSlug(src.Name)));
        }
    }
}