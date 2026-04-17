using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;
using ServiceCenterApp.Domain.ValueObjects;

public class CreateRepairRequest
{
    private readonly IRequestRepository _repository;

    public CreateRepairRequest(IRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Execute(CreateRepairRequestDto dto)
    {
        var request = new RepairRequest
        {
            Id = Guid.NewGuid(),
            ClientId = dto.ClientId,
            Description = dto.Description,
            Status = RequestStatus.New,
            CreatedAt = DateTime.UtcNow,
            ClientAddress = new Address(dto.Street, dto.City, dto.ZipCode),
            EquipmentType = new EquipmentType { Id = dto.EquipmentTypeId }
        };

        await _repository.AddAsync(request);
        return request.Id;
    }
}