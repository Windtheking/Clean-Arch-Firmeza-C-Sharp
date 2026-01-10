using CleanFirmeza.Application.Interfaces;
using CleanFirmeza.Application.Interfaces.Auth;
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
        Console.WriteLine("todo registrado exitosamente");
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();


        return services;
    }
}