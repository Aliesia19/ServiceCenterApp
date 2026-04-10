using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class CreateService
{
    private readonly IRepository<Service> _repo;

    public CreateService(IRepository<Service> repo)
    {
        _repo = repo;
    }

    public async Task Execute(ServiceDto dto)
    {
        await _repo.AddAsync(new Service
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            BasePrice = dto.BasePrice
        });
    }
}