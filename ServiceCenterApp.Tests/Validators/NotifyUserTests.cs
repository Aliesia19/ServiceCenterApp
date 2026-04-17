using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class NotifyUserTests
{
    private readonly NotifyUserValidator _validator = new();

    [Fact]
    public void Should_Throw_When_UserId_Empty()
    {
        var command = new NotifyUserCommand { UserId = Guid.Empty };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }
}