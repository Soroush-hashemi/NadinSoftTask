using Application.User.Services;
using Domain.Product;
using Domain.User;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddTransient<IUserService, UserService>();

        services.AddDbContext<Context>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}