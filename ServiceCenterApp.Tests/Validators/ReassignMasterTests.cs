using AutoFixture;
using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class ReassignMasterTests
{
    private readonly ReassignMasterValidator _validator = new();
    private readonly Fixture _fixture = new();

    [Fact]
    public void Should_Throw_When_Invalid()
    {
        var command = _fixture.Build<ReassignMasterCommand>()
            .With(x => x.NewMasterId, Guid.Empty)
            .Create();

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }
}