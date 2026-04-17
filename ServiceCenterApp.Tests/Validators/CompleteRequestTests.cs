using AutoFixture;
using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class CompleteRequestTests
{
    private readonly CompleteRequestValidator _validator = new();
    private readonly Fixture _fixture = new();

    [Fact]
    public void Should_Throw_When_RequestId_Empty()
    {
        var command = new CompleteRequestCommand { RequestId = Guid.Empty };

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Should_Pass_When_Valid()
    {
        var command = _fixture.Create<CompleteRequestCommand>();

        Action act = () => _validator.Validate(command);

        act.Should().NotThrow();
    }
}