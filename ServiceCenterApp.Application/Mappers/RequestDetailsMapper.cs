using ServiceCenterApp.Application.DTO;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.Enums;

namespace ServiceCenterApp.Application.Mappers
{
    public class RequestDetailsMapper : IMapper<RepairRequest, RequestDetailsDto>
    {
        private readonly ChecklistItemMapper _checklistMapper = new ChecklistItemMapper();

        public RequestDetailsDto ToDto(RepairRequest domain)
        {
            return new RequestDetailsDto
            {
                Id = domain.Id,
                Description = domain.Description,
                Status = domain.Status.ToString(),
                ClientName = domain.Client.FullName,
                MasterName = domain.Master?.FullName ?? string.Empty,
                Checklist = domain.Checklist.Select(c => _checklistMapper.ToDto(c)).ToList()
            };
        }

        public RepairRequest ToDomain(RequestDetailsDto dto)
        {
            return new RepairRequest
            {
                Id = dto.Id,
                Description = dto.Description,
                Status = Enum.Parse<RequestStatus>(dto.Status),
                Checklist = dto.Checklist.Select(c => _checklistMapper.ToDomain(c)).ToList()
            };
        }
    }
}