using App.Application.Contracts.Persistence;
using App.Application.Features.Carts;
using App.Application.Features.Categories;
using App.Application.Features.ErrorLogFeatures;
using App.Application.Features.Products;
using App.Domain.Options;
using App.Persistence.Interceptors;
using App.Persistence.Repositories.Categories;
using App.Persistence.Repositories.ErrorLogs;
using App.Persistence.Repositories.Products;
using App.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Persistence.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionStrings =
                    configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();

                options.UseSqlServer(connectionStrings!.SqlServer,
                    sqlServerOptionsAction =>
                    {
                        sqlServerOptionsAction.MigrationsAssembly(typeof(PersistenceAssembly).Assembly.FullName);
                    });

                options.AddInterceptors(new AuditDbContextInterceptor());
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IErrorLogRepository, ErrorLogRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IErrorLogService, ErrorLogService>();

            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}