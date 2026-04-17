using Microsoft.EntityFrameworkCore;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;

namespace ServiceCenterApp.Infrastructure.DataAccess.MsSql.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}