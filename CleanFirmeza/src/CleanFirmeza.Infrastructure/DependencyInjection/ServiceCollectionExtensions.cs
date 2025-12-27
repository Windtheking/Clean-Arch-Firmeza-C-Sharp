using CleanFirmeza.Application.Interfaces;
using CleanFirmeza.Application.Services;
using CleanFirmeza.Domain.Interface;
using CleanFirmeza.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanFirmeza.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}