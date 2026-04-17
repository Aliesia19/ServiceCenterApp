using ServiceCenterApp.Domain.Entities;

namespace ServiceCenterApp.Domain.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<List<Service>> GetAllActiveAsync();
    }
}