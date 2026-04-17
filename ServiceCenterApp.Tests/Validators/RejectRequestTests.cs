using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class RejectRequestTests
{
    private readonly RejectRequestValidator _validator = new();

    [Fact]
    public void Should_Throw_When_Reason_Empty()
    {
        var command = new RejectRequestCommand
        {
            RequestId = Guid.NewGuid(),
            Reason = ""
        };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }
}