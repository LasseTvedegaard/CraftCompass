using Bogus;
using Model;
using System.Data.SqlClient;
using System.Data;
using DataAccess;
using Xunit;
using FluentAssertions;
using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;

public class EmployeeRepositoryIntegrationTests : IDisposable {
    private readonly IDbConnection _dbConnectionTest;
    private IDbTransaction _transaction;
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
        _transaction = _dbConnectionTest.BeginTransaction();

        // Brug konstruktøren der tager en forbindelsesstreng direkte for testinstanser
        _employeeAccess = new EmployeeAccess(connectionString);
    }

        [Fact]
    public async Task CreateEmployee_ShouldSuccessfullyAddEmployee() {
        // Arrange
        var faker = new Faker<Employee>()
            .RuleFor(o => o.Name, f => f.Name.FullName())
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Role, f => f.Name.JobTitle());

        var newEmployee = faker.Generate();

        // Act
        var createdEmployeeId = await _employeeAccess.Create(newEmployee);
        var createdEmployee = await _employeeAccess.Get(createdEmployeeId);

        // Assert
        createdEmployee.Should().NotBeNull();
        createdEmployee.Name.Should().Be(newEmployee.Name);
        createdEmployee.Email.Should().Be(newEmployee.Email);
        // Fortsæt med at validere resten af feltene som nødvendigt
    }

    public void Dispose() {
        _transaction.Rollback();
        _dbConnectionTest.Dispose();
    }
}
