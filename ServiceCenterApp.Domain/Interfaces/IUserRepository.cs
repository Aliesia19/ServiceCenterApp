using ServiceCenterApp.Domain.Entities;

namespace ServiceCenterApp.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);

        Task<List<User>> GetByRoleAsync(string role);
    }
}