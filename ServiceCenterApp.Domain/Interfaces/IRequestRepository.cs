using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;

namespace ServiceCenterApp.Domain.Interfaces
{
    public interface IRequestRepository : IRepository<RepairRequest>
    {
        Task<List<RepairRequest>> GetRequestsByClientIdAsync(Guid clientId);
        Task<List<RepairRequest>> GetRequestsByMasterIdAsync(Guid masterId);

        Task<List<RepairRequest>> GetByStatusAsync(RequestStatus status);
    }
}