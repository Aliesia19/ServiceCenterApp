using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;

public class GetStatistics
{
    private readonly IRequestRepository _repo;

    public GetStatistics(IRequestRepository repo)
    {
        _repo = repo;
    }

    public async Task<StatisticsDto> Execute()
    {
        var all = await _repo.GetAllAsync();

        return new StatisticsDto
        {
            TotalRequests = all.Count,
            CompletedRequests = all.Count(r => r.Status == RequestStatus.Completed),
            TotalRevenue = all.Sum(r => r.TotalPrice)
        };
    }
}