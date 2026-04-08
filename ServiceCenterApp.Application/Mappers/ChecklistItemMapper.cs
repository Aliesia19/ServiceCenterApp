using ServiceCenterApp.Application.DTO;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;

namespace ServiceCenterApp.Application.Mappers
{
    public class ChecklistItemMapper : IMapper<ChecklistItem, ChecklistItemDto>
    {
        public ChecklistItemDto ToDto(ChecklistItem domain)
        {
            return new ChecklistItemDto
            {
                ServiceName = domain.Service.Name,
                Quantity = domain.Quantity,
                Price = domain.Price
            };
        }

        public ChecklistItem ToDomain(ChecklistItemDto dto)
        {
            return new ChecklistItem
            {
                Quantity = dto.Quantity,
                Price = dto.Price,
                Service = new Service { Name = dto.ServiceName }
            };
        }
    }
}