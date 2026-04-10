using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;

public class UpdateRequestStatus
{
    private readonly IRequestRepository _repo;

    public UpdateRequestStatus(IRequestRepository repo)
    {
        _repo = repo;
    }

    public async Task Execute(UpdateRequestStatusDto dto)
    {
        var request = await _repo.GetByIdAsync(dto.RequestId);
        if (request == null) return;

        request.Status = Enum.Parse<RequestStatus>(dto.Status);
        await _repo.UpdateAsync(request);
    }
}