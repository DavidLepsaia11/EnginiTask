using EnginiTask.API.Controllers;
using Microsoft.EntityFrameworkCore;
using EnginiTask.Repository;
using EnginiTask.Repository.Database;
using EnginiTask.Service;
using EnginiTask.Service.Interfaces.Repositories;
using EnginiTask.Service.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace EnginiTask.Tests.Configurations
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureServices(
            this IServiceCollection services,
            IHostEnvironment environment,
            IConfiguration configuration)
        {
            services.AddSingleton(environment);
            services.AddSingleton(configuration);

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddTransient<EmployeesController>();

            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<EmployeesDbContext>(options =>
                options.UseInMemoryDatabase("EmployeesDb")); 

            return services;
        }
    }
}
