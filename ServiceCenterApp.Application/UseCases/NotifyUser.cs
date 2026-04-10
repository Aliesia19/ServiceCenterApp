using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class NotifyUser
{
    private readonly IRepository<Notification> _repo;

    public NotifyUser(IRepository<Notification> repo)
    {
        _repo = repo;
    }

    public async Task Execute(Guid userId, string message)
    {
        await _repo.AddAsync(new Notification
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Message = message,
            CreatedAt = DateTime.UtcNow
        });
    }
}