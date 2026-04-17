using AutoFixture;
using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class AssignMasterTests
{
    private readonly AssignMasterValidator _validator = new();
    private readonly Fixture _fixture = new();

    [Fact]
    public void Should_Throw_When_RequestId_Empty()
    {
        var command = _fixture.Build<AssignMasterCommand>()
            .With(x => x.RequestId, Guid.Empty)
            .Create();

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Should_Throw_When_MasterId_Empty()
    {
        var command = _fixture.Build<AssignMasterCommand>()
            .With(x => x.MasterId, Guid.Empty)
            .Create();

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Should_Pass_When_Valid()
    {
        var command = _fixture.Create<AssignMasterCommand>();

        Action act = () => _validator.Validate(command);

        act.Should().NotThrow();
    }
}