using ServiceCenterApp.Application.DTO;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;

namespace ServiceCenterApp.Application.Mappers
{
    public class RepairRequestMapper : IMapper<RepairRequest, RepairRequestDto>
    {
        public RepairRequestDto ToDto(RepairRequest domain)
        {
            return new RepairRequestDto
            {
                Id = domain.Id,
                ClientName = domain.Client.FullName,
                EquipmentType = domain.EquipmentType?.Name ?? string.Empty,
                Status = domain.Status.ToString(),
                TotalPrice = domain.TotalPrice,
                CreatedAt = domain.CreatedAt
            };
        }

        public RepairRequest ToDomain(RepairRequestDto dto)
        {
            return new RepairRequest
            {
                Id = dto.Id,
                TotalPrice = dto.TotalPrice,
                Status = Enum.Parse<RequestStatus>(dto.Status),
                CreatedAt = dto.CreatedAt
            };
        }
    }
}