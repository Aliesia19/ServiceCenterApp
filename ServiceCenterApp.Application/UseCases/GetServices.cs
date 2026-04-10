using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Interfaces;

public class GetServices
{
    private readonly IRepository<Service> _repo;

    public GetServices(IRepository<Service> repo)
    {
        _repo = repo;
    }

    public async Task<List<Service>> Execute()
    {
        return await _repo.GetAllAsync();
    }
}