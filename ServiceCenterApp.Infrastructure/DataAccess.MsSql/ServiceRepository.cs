using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;

namespace ServiceCenterApp.Infrastructure.DataAccess.MsSql.Repositories
{
    public class ServiceRepository : Repository<Service>
    {
        public ServiceRepository(AppDbContext context) : base(context)
        {
        }
    }
}