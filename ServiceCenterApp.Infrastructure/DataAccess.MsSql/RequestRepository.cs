using Microsoft.EntityFrameworkCore;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Domain.Interfaces;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;

namespace ServiceCenterApp.Infrastructure.DataAccess.MsSql.Repositories
{
    public class RequestRepository : Repository<RepairRequest>, IRequestRepository
    {
        public RequestRepository(AppDbContext context) : base(context) { }

        public async Task<List<RepairRequest>> GetByClientIdAsync(Guid clientId)
        {
            return await _context.RepairRequests
                .Where(r => r.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<List<RepairRequest>> GetByMasterIdAsync(Guid masterId)
        {
            return await _context.RepairRequests
                .Where(r => r.MasterId == masterId)
                .ToListAsync();
        }

        public async Task<List<RepairRequest>> GetByStatusAsync(RequestStatus status)
        {
            return await _context.RepairRequests
                .Where(r => r.Status == status)
                .ToListAsync();
        }
    }
}