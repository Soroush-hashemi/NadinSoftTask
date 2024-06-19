using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Product.Create;
using Domain.Product;
using Application.Product;
using FluentValidation;
using Query.Product.GetById;

namespace Config;
public static class Bootstrapper
{
    public static void ConfigBootstrapper(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Init(services, connectionString);

        services.AddMediatR(typeof(CreateProductCommand).Assembly);
        services.AddMediatR(typeof(CreateProductCommandHandler).Assembly);

        services.AddMediatR(typeof(GetProductByIdQuery).Assembly);
        services.AddMediatR(typeof(GetProductByIdQueryHandler).Assembly);

        services.AddTransient<IProductDomainService, ProductDomainService>();


        // facade 

        services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
    }
}
