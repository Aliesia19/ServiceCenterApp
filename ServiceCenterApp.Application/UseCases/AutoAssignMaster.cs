using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;

public class AutoAssignMaster
{
    private readonly IRepository<User> _userRepo;
    private readonly IRequestRepository _requestRepo;

    public AutoAssignMaster(IRepository<User> userRepo, IRequestRepository requestRepo)
    {
        _userRepo = userRepo;
        _requestRepo = requestRepo;
    }

    public async Task Execute(Guid requestId)
    {
        var masters = (await _userRepo.GetAllAsync())
            .Where(u => u.Role == UserRole.Master)
            .ToList();

        var requests = await _requestRepo.GetAllAsync();

        var leastLoaded = masters
            .OrderBy(m => requests.Count(r => r.MasterId == m.Id))
            .FirstOrDefault();

        if (leastLoaded == null) return;

        var request = await _requestRepo.GetByIdAsync(requestId);
        if (request == null) return;

        request.MasterId = leastLoaded.Id;
        request.Status = RequestStatus.InProgress;

        await _requestRepo.UpdateAsync(request);
    }
}