using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;

public class AssignMaster
{
    private readonly IRequestRepository _repo;

    public AssignMaster(IRequestRepository repo)
    {
        _repo = repo;
    }

    public async Task Execute(AssignMasterDto dto)
    {
        var request = await _repo.GetByIdAsync(dto.RequestId);
        if (request == null) return;

        request.MasterId = dto.MasterId;
        request.Status = RequestStatus.InProgress;

        await _repo.UpdateAsync(request);
    }
}