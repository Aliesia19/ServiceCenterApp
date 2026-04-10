using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class GetEquipmentTypes
{
    private readonly IRepository<EquipmentType> _repo;

    public GetEquipmentTypes(IRepository<EquipmentType> repo)
    {
        _repo = repo;
    }

    public async Task<List<EquipmentType>> Execute()
    {
        return await _repo.GetAllAsync();
    }
}