using Bogus;
using DataAccess;
using DataAccess.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xunit;

public class EmployeeRepositoryIntegrationTests : IDisposable {
    private readonly IDbConnection _dbConnectionTest;
    private readonly ICRUDAccess<Employee> _employeeAccess;
    private readonly IConfiguration _configuration;

    public EmployeeRepositoryIntegrationTests() {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.Test.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = _configuration.GetConnectionString("TestDatabaseConnection");
        _dbConnectionTest = new SqlConnection(connectionString);
        _dbConnectionTest.Open();

        _employeeAccess = new EmployeeAccess(connectionString);
    }

    private async Task SetupAsync() {

        await _employeeAccess.DeleteAll();

        var faker = new Faker<Employee>()
            .RuleFor(o => o.Name, f => f.Name.FullName())
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Role, f => f.Name.JobTitle());

        for (int i = 0; i < 2; i++) {
            var newEmployee = faker.Generate();
            await _employeeAccess.Create(newEmployee);
        }
    }

    private async Task TeardownAsync() {
        var employees = await _employeeAccess.GetAll();
        foreach (var employee in employees) {
            if (employee.Email.EndsWith("@test.com")) {
                await _employeeAccess.Delete(employee.EmployeeId);
            }
        }
    }

    [Fact]
    public async Task CreateEmployee_ShouldSuccessfullyAddEmployee() {
        // Arrange
        await SetupAsync();

        var faker = new Faker<Employee>()
            .RuleFor(o => o.Name, f => f.Name.FullName())
            .RuleFor(o => o.Email, f => f.Internet.Email("test.com"))
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Role, f => f.Name.JobTitle());

        var newEmployee = faker.Generate();

        // Act
        var createdEmployeeId = await _employeeAccess.Create(newEmployee);

        // Assert
        createdEmployeeId.Should().BeGreaterThan(0);

        var createdEmployee = await _employeeAccess.Get(createdEmployeeId);
        createdEmployee.Should().NotBeNull();

        createdEmployee.Name.Should().Be(newEmployee.Name);
        createdEmployee.Email.Should().Be(newEmployee.Email);

        // Teardown
        await TeardownAsync();
    }

    public void Dispose() {
        _dbConnectionTest?.Dispose();
    }
}
