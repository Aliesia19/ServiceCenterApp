using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using ServiceCenterApp.Application.Mappers;
using ServiceCenterApp.Domain.Entities;
using Xunit;

public class ChatMessageTests
{
    private readonly ChatMessageMapper _mapper = new();
    private readonly Fixture _fixture;

    public ChatMessageTests()
    {
        _fixture = new Fixture();

        _fixture.Behaviors
            .OfType<ThrowingRecursionBehavior>()
            .ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));

        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public void ToDto_Should_Map_Correctly()
    {
        var domain = _fixture.Build<ChatMessage>()
            .With(x => x.Sender, new User { FullName = "John" })
            .Create();

        var result = _mapper.ToDto(domain);

        result.Id.Should().Be(domain.Id);
        result.Message.Should().Be(domain.Message);
        result.SenderName.Should().Be("John");
        result.SentAt.Should().Be(domain.SentAt);
    }

    [Fact]
    public void ToDomain_Should_Map_Correctly()
    {
        var dto = _fixture.Create<ChatMessageDto>();

        var result = _mapper.ToDomain(dto);

        result.Id.Should().Be(dto.Id);
        result.Message.Should().Be(dto.Message);
        result.SentAt.Should().Be(dto.SentAt);
    }
}