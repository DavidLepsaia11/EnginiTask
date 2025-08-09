using EnginiTask.API.Controllers;
using EnginiTask.Domain;
using EnginiTask.Tests.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace EnginiTask.Tests
{
    [Collection("DbFixture")]
    public sealed class EmployeesTests : UnitTestBase
    {
        private readonly EmployeesController _controller;

        public EmployeesTests()
        {
            _controller = _services
            .BuildServiceProvider()
            .GetService<EmployeesController>()!;
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task ShouldGetById(int id)
        {
            var response = await _controller.Get(id)!;
            
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async Task ShouldGetAll()
        {
            var response = await _controller.GetAll();
            Assert.IsType<OkObjectResult>(response.Result);
            var employees = (response.Result as OkObjectResult)?.Value as IEnumerable<Employee>;
            Assert.NotEmpty(employees!);
        }

    }
}