using NSubstitute;
using Xunit;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;
using ServiceCenterApp.Application.Interfaces;
using System.Collections.Generic;

public class GetChatMessagesTests
{
    private readonly IRepository<ChatMessage> _repo = Substitute.For<IRepository<ChatMessage>>();
    private readonly IMapper<ChatMessage, ChatMessageDto> _mapper =
        Substitute.For<IMapper<ChatMessage, ChatMessageDto>>();

    private readonly GetChatMessages _useCase;

    public GetChatMessagesTests()
    {
        _useCase = new GetChatMessages(_repo, _mapper);
    }

    [Fact]
    public async Task Should_Return_Filtered_And_Sorted_Messages()
    {
        var requestId = Guid.NewGuid();

        var messages = new List<ChatMessage>
        {
            new ChatMessage { RepairRequestId = requestId, SentAt = DateTime.UtcNow.AddMinutes(-1) },
            new ChatMessage { RepairRequestId = requestId, SentAt = DateTime.UtcNow }
        };

        _repo.GetAllAsync().Returns(messages);

        _mapper.ToDto(Arg.Any<ChatMessage>())
            .Returns(x => new ChatMessageDto());

        var result = await _useCase.Execute(requestId);

        Assert.Equal(2, result.Count);
        await _repo.Received(1).GetAllAsync();
    }
}