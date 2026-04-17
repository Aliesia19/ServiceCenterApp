using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class CreateServiceTests
{
    private readonly CreateServiceValidator _validator = new();

    [Fact]
    public void Should_Throw_When_Name_Empty()
    {
        var command = new CreateServiceCommand { Name = "" };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Should_Throw_When_Price_Negative()
    {
        var command = new CreateServiceCommand { Name = "Fix", BasePrice = -1 };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }
}