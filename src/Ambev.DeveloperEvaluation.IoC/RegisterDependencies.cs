using Ambev.DeveloperEvaluation.AppService;
using Ambev.DeveloperEvaluation.AppService.Interface;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Infra;
using Ambev.DeveloperEvaluation.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC
{
    public static class DependencyResolver
    {
        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString, b=>b.MigrationsAssembly("Ambev.DeveloperEvaluation.Api")));

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IOrderAppService, OrderAppService>();
        }
    }
}
