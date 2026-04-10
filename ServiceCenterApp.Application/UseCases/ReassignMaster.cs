using ServiceCenterApp.Domain.Interfaces;

public class ReassignMaster
{
    private readonly IRequestRepository _repo;

    public ReassignMaster(IRequestRepository repo)
    {
        _repo = repo;
    }

    public async Task Execute(AssignMasterDto dto)
    {
        var request = await _repo.GetByIdAsync(dto.RequestId);
        if (request == null) return;

        request.MasterId = dto.MasterId;

        await _repo.UpdateAsync(request);
    }
}