using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class SendMessage
{
    private readonly IRepository<ChatMessage> _repo;

    public SendMessage(IRepository<ChatMessage> repo)
    {
        _repo = repo;
    }

    public async Task Execute(SendMessageDto dto)
    {
        var message = new ChatMessage
        {
            Id = Guid.NewGuid(),
            RepairRequestId = dto.RequestId,
            SenderId = dto.SenderId,
            Message = dto.Message,
            SentAt = DateTime.UtcNow
        };

        await _repo.AddAsync(message);
    }
}