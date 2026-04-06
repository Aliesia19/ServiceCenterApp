// ServiceCenterApp.Domain/Interfaces/IRequestRepository.cs
using ServiceCenterApp.Domain.Entities;

namespace ServiceCenterApp.Domain.Interfaces
{
    public interface IRequestRepository : IRepository<RepairRequest>
    {
        Task<List<RepairRequest>> GetRequestsByClientIdAsync(Guid clientId);
        Task<List<RepairRequest>> GetRequestsByMasterIdAsync(Guid masterId);
    }
}