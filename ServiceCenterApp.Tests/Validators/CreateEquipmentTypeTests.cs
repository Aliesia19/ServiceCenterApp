using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class CreateEquipmentTypeTests
{
    private readonly CreateEquipmentTypeValidator _validator = new();

    [Fact]
    public void Should_Throw_When_Name_Empty()
    {
        var command = new CreateEquipmentTypeCommand { Name = "" };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Should_Throw_When_Name_TooShort()
    {
        var command = new CreateEquipmentTypeCommand { Name = "A" };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Should_Pass_When_Valid()
    {
        var command = new CreateEquipmentTypeCommand { Name = "Laptop" };

        Action act = () => _validator.Validate(command);

        act.Should().NotThrow();
    }
}