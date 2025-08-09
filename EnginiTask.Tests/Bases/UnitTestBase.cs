using EnginiTask.Tests.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginiTask.Tests.Bases
{
    public abstract class UnitTestBase
    {
        protected readonly ServiceCollection _services;

        protected UnitTestBase()
        {
            _services = new ServiceCollection();
            var environment = new TestHostEnvironment();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _services
                .ConfigureServices(environment, configuration)
                .ConfigureDbContext();
        }
    }
}
