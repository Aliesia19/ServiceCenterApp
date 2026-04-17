using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class UpdateServiceTests
{
    private readonly UpdateServiceValidator _validator = new();

    [Fact]
    public void Should_Throw_When_Name_Empty()
    {
        var command = new UpdateServiceCommand
        {
            Id = Guid.NewGuid(),
            Name = "",
            BasePrice = 10
        };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }
}