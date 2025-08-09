using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginiTask.Tests.Configurations
{
    internal class TestHostEnvironment : IHostEnvironment
    {
        public string ApplicationName { get; set; } = "EnginiTask.API";
        public string EnvironmentName { get; set; } = "Test";
        public string ContentRootPath { get; set; }  = Directory.GetCurrentDirectory();
        public IFileProvider ContentRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
