using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;

public class RejectRequest
{
    private readonly IRequestRepository _repo;

    public RejectRequest(IRequestRepository repo)
    {
        _repo = repo;
    }

    public async Task Execute(Guid requestId)
    {
        var request = await _repo.GetByIdAsync(requestId);
        if (request == null) return;

        request.MasterId = null;
        request.Status = RequestStatus.Canceled;

        await _repo.UpdateAsync(request);
    }
}