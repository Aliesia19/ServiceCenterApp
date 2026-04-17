using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class DeleteServiceTests
{
    private readonly DeleteServiceValidator _validator = new();

    [Fact]
    public void Should_Throw_When_Id_Empty()
    {
        var command = new DeleteServiceCommand { Id = Guid.Empty };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }
}