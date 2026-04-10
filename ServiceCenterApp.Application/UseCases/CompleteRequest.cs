using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;

public class CompleteRequest
{
    private readonly IRequestRepository _repo;

    public CompleteRequest(IRequestRepository repo)
    {
        _repo = repo;
    }

    public async Task Execute(Guid requestId)
    {
        var request = await _repo.GetByIdAsync(requestId);
        if (request == null) return;

        request.Status = RequestStatus.Completed;
        request.ClosedAt = DateTime.UtcNow;

        await _repo.UpdateAsync(request);
    }
}