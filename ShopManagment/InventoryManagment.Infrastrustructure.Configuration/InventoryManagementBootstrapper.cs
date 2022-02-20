using InventoryManagement.Application;
using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.Extensions.DependencyInjection;
using System;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EFCore.context;
using InventoryManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Configuration
{
    public class InventoryManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IInventoryApplication, InventoryApplication>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddDbContext<InventoryContext>(x=>x.UseSqlServer(connectionString));
        }
    }
}
