using ServiceCenterApp.Domain.Interfaces;

public class CalculateTotalPrice
{
    private readonly IRequestRepository _repo;

    public CalculateTotalPrice(IRequestRepository repo)
    {
        _repo = repo;
    }

    public async Task Execute(Guid requestId)
    {
        var request = await _repo.GetByIdAsync(requestId);
        if (request == null) return;

        request.TotalPrice = request.Checklist.Sum(c => c.Price * c.Quantity);

        await _repo.UpdateAsync(request);
    }
}