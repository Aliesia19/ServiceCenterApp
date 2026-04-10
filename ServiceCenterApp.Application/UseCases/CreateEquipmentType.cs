using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class CreateEquipmentType
{
    private readonly IRepository<EquipmentType> _repo;

    public CreateEquipmentType(IRepository<EquipmentType> repo)
    {
        _repo = repo;
    }

    public async Task Execute(EquipmentTypeDto dto)
    {
        await _repo.AddAsync(new EquipmentType
        {
            Id = Guid.NewGuid(),
            Name = dto.Name
        });
    }
}