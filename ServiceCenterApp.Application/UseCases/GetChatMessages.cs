using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class GetChatMessages
{
    private readonly IRepository<ChatMessage> _repo;
    private readonly IMapper<ChatMessage, ChatMessageDto> _mapper;

    public GetChatMessages(IRepository<ChatMessage> repo, IMapper<ChatMessage, ChatMessageDto> mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<ChatMessageDto>> Execute(Guid requestId)
    {
        var all = await _repo.GetAllAsync();
        return all
            .Where(m => m.RepairRequestId == requestId)
            .OrderBy(m => m.SentAt)
            .Select(_mapper.ToDto)
            .ToList();
    }
}