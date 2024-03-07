using Bogus;
using DataAccess.Interfaces;
using FluentAssertions;
using Model;
using Moq;

namespace CraftPro.Tests.DataAccessTest;


public class EmployeeAccessTests
{
    [Fact]
    public async Task CreateEmployee_ShouldAddEmployee_WhenEmployeeIsValidAsync()
    {
        // Arrange
        var faker = new Faker<Employee>()
            .RuleFor(o => o.EmployeeId, f => f.Random.Int(min: 1)) 
            .RuleFor(o => o.Name, f => f.Name.FullName())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Role, f => f.Name.JobTitle());

        var newEmployee = faker.Generate();
        var mockRepository = new Mock<ICRUDAccess<Employee>>();
        var fakeId = 123; 
        mockRepository.Setup(repo => repo.Create(newEmployee)).ReturnsAsync(fakeId);

        var repository = mockRepository.Object;

        // Act
        var createdEmployeeId = await repository.Create(newEmployee);

        // Assert
        createdEmployeeId.Should().Be(fakeId);

    }

    [Fact]
    public async Task GetAllEmployees_ShouldReturnAllEmployees_WhenCalledAsync() {
        // Arrange
        var faker = new Faker<Employee>()
            .RuleFor(o => o.EmployeeId, f => f.Random.Int(min: 1))
            .RuleFor(o => o.Name, f => f.Name.FullName())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Role, f => f.Name.JobTitle());

        var fakeEmployees = faker.Generate(5); 
        var mockRepository = new Mock<ICRUDAccess<Employee>>();

        mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(fakeEmployees);

        var repository = mockRepository.Object;

        // Act
        var employees = await repository.GetAll();

        // Assert
        employees.Should().BeEquivalentTo(fakeEmployees); 
    }
}



