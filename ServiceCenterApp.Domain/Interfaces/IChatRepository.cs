using ServiceCenterApp.Domain.Entities;

namespace ServiceCenterApp.Domain.Interfaces
{
    public interface IChatRepository : IRepository<ChatMessage>
    {
        Task<List<ChatMessage>> GetByRequestIdAsync(Guid requestId);

        Task<List<ChatMessage>> GetLastMessagesAsync(Guid requestId, int count);
    }
}