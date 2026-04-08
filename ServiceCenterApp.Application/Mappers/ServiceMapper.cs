using ServiceCenterApp.Application.DTO;
using ServiceCenterApp.Application.Interfaces;
using ServiceCenterApp.Domain.Entities;

namespace ServiceCenterApp.Application.Mappers
{
    public class ServiceMapper : IMapper<Service, ServiceDto>
    {
        public ServiceDto ToDto(Service domain)
        {
            return new ServiceDto
            {
                Id = domain.Id,
                Name = domain.Name,
                BasePrice = domain.BasePrice
            };
        }

        public Service ToDomain(ServiceDto dto)
        {
            return new Service
            {
                Id = dto.Id,
                Name = dto.Name,
                BasePrice = dto.BasePrice
            };
        }
    }
}