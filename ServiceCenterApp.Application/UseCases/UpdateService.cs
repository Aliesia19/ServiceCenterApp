using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class UpdateService
{
    private readonly IRepository<Service> _repo;

    public UpdateService(IRepository<Service> repo)
    {
        _repo = repo;
    }

    public async Task Execute(ServiceDto dto)
    {
        var service = await _repo.GetByIdAsync(dto.Id);
        if (service == null) return;

        service.Name = dto.Name;
        service.BasePrice = dto.BasePrice;

        await _repo.UpdateAsync(service);
    }
}