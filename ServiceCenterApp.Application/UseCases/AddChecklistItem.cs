using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class AddChecklistItem
{
    private readonly IRequestRepository _repo;

    public AddChecklistItem(IRequestRepository repo)
    {
        _repo = repo;
    }

    public async Task Execute(AddChecklistItemDto dto)
    {
        var request = await _repo.GetByIdAsync(dto.RequestId);
        if (request == null) return;

        request.Checklist.Add(new ChecklistItem
        {
            Id = Guid.NewGuid(),
            ServiceId = dto.ServiceId,
            Quantity = dto.Quantity
        });

        await _repo.UpdateAsync(request);
    }
}