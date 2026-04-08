using ServiceCenterApp.Application.DTO;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;

namespace ServiceCenterApp.Application.Mappers
{
    public class NotificationMapper : IMapper<Notification, NotificationDto>
    {
        public NotificationDto ToDto(Notification domain)
        {
            return new NotificationDto
            {
                Id = domain.Id,
                Message = domain.Message,
                IsRead = domain.IsRead
            };
        }

        public Notification ToDomain(NotificationDto dto)
        {
            return new Notification
            {
                Id = dto.Id,
                Message = dto.Message,
                IsRead = dto.IsRead
            };
        }
    }
}