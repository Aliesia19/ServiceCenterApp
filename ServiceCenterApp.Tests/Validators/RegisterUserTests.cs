using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Validators;
using Xunit;

public class RegisterUserTests
{
    private readonly RegisterUserValidator _validator = new();

    [Fact]
    public void Should_Throw_When_Email_Invalid()
    {
        var command = new RegisterUserCommand
        {
            FullName = "Test",
            Email = "invalid",
            Password = "123456"
        };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }
}