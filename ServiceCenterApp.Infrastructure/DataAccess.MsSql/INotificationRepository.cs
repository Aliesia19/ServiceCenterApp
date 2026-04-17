using ServiceCenterApp.Domain.Entities;

namespace ServiceCenterApp.Domain.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<Notification>> GetByUserIdAsync(Guid userId);

        Task<int> GetUnreadCountAsync(Guid userId);
    }
}