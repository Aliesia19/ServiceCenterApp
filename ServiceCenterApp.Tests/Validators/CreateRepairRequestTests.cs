using AutoFixture;
using FluentAssertions;
using ServiceCenterApp.Application.Commands;
using Xunit;

public class CreateRepairRequestTests
{
    private readonly CreateRepairRequestValidator _validator = new();
    private readonly Fixture _fixture = new();

    [Fact]
    public void Should_Throw_When_ClientId_Empty()
    {
        var command = _fixture.Build<CreateRepairRequestCommand>()
            .With(x => x.ClientId, Guid.Empty)
            .Create();

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Should_Throw_When_Description_Empty()
    {
        var command = _fixture.Build<CreateRepairRequestCommand>()
            .With(x => x.Description, "")
            .Create();

        Action act = () => _validator.Validate(command);

        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Should_Pass_When_Valid()
    {
        var command = _fixture.Create<CreateRepairRequestCommand>();

        Action act = () => _validator.Validate(command);

        act.Should().NotThrow();
    }
}