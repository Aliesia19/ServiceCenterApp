using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class UpdateRequestStatusTests
{
    private readonly UpdateRequestStatusValidator _validator = new();

    [Fact]
    public void Should_Throw_When_Status_Invalid()
    {
        var command = new UpdateRequestStatusCommand
        {
            RequestId = Guid.NewGuid(),
            Status = "INVALID"
        };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }
}