using EmployeeManager.Core.Data;
using EmployeeManager.Core.Models;
using EmployeeManager.Core.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EmployeeManager.Tests
{
    public class EmployeeServiceTests
    {
        private EmployeeService GetServiceWithInMemoryDb(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var context = new ApplicationDbContext(options);
            return new EmployeeService(context);
        }

        [Fact]
        public void AddEmployee_ShouldIncreaseCount()
        {
            // Arrange
            var service = GetServiceWithInMemoryDb("AddTest");
            var employee = new Employee { Name = "Анна", Age = 25, Department = "IT" };

            // Act
            service.AddEmployee(employee);
            var result = service.GetAllEmployees();

            // Assert
            Assert.Single(result);
            Assert.Equal("Анна", result[0].Name);
        }

        [Fact]
        public void RemoveEmployee_ShouldDelete()
        {
            // Arrange
            var service = GetServiceWithInMemoryDb("DeleteTest");
            var employee = new Employee { Name = "Олег", Age = 30, Department = "HR" };
            service.AddEmployee(employee);

            // Act
            var success = service.RemoveEmployee(service.GetAllEmployees().First().Id);
            var result = service.GetAllEmployees();

            // Assert
            Assert.True(success);
            Assert.Empty(result);
        }
    }
}