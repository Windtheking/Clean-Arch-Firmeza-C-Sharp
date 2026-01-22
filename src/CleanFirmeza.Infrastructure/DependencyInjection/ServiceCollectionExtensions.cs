using CleanFirmeza.Application.Interfaces;
using CleanFirmeza.Application.Interfaces.Auth;
using CleanFirmeza.Application.Interfaces.Import;
using CleanFirmeza.Application.Services.import;
using CleanFirmeza.Domain.Interface;
using CleanFirmeza.Infrastructure.Repositories;
using CleanFirmeza.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanFirmeza.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductExcelMapper, ProductExcelMapper>();
        services.AddScoped<IProductService, ProductService>();


        return services;
    }
}