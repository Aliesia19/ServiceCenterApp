using ServiceCenterApp.Application.DTO;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;

namespace ServiceCenterApp.Application.Mappers
{
    public class EquipmentTypeMapper : IMapper<EquipmentType, EquipmentTypeDto>
    {
        public EquipmentTypeDto ToDto(EquipmentType domain)
        {
            return new EquipmentTypeDto
            {
                Id = domain.Id,
                Name = domain.Name
            };
        }

        public EquipmentType ToDomain(EquipmentTypeDto dto)
        {
            return new EquipmentType
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}