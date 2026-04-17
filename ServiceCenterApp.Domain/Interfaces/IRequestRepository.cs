using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;

namespace ServiceCenterApp.Domain.Interfaces
{
    public interface IRequestRepository : IRepository<RepairRequest>
    {
        Task<List<RepairRequest>> GetByClientIdAsync(Guid clientId);

        Task<List<RepairRequest>> GetByMasterIdAsync(Guid masterId);

        Task<List<RepairRequest>> GetByStatusAsync(RequestStatus status);
    }
}