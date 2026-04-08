using ServiceCenterApp.Application.DTO;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;

namespace ServiceCenterApp.Application.Mappers
{
    public class UserMapper : IMapper<User, UserDto>
    {
        public UserDto ToDto(User domain)
        {
            return new UserDto
            {
                Id = domain.Id,
                FullName = domain.FullName,
                Email = domain.Email,
                Phone = domain.Phone,
                Role = domain.Role.ToString()
            };
        }

        public User ToDomain(UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Role = Enum.Parse<UserRole>(dto.Role)
            };
        }
    }
}