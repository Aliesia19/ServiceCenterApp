using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Validators;
using Xunit;

public class LoginTests
{
    private readonly LoginValidator _validator = new();

    [Fact]
    public void Should_Throw_When_Email_Empty()
    {
        var command = new LoginCommand { Email = "", Password = "123" };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }
}