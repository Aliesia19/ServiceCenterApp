using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Repositories;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql;

namespace ServiceCenterApp.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
     
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<UserRepository>();
            services.AddScoped<RequestRepository>();
            services.AddScoped<ServiceRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRepository<Service>, ServiceRepository>();


            services.AddScoped<DatabaseInitializer>();

            return services;
        }
    }
}