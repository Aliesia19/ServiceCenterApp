using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class DeleteService
{
    private readonly IRepository<Service> _repo;

    public DeleteService(IRepository<Service> repo)
    {
        _repo = repo;
    }

    public async Task Execute(Guid id)
    {
        var service = await _repo.GetByIdAsync(id);
        if (service == null) return;

        await _repo.DeleteAsync(service);
    }
}