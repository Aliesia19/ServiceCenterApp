using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class SendMessageTests
{
    private readonly SendMessageValidator _validator = new();

    [Fact]
    public void Should_Throw_When_Message_Empty()
    {
        var command = new SendMessageCommand
        {
            RequestId = Guid.NewGuid(),
            SenderId = Guid.NewGuid(),
            Message = ""
        };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }
}