// ServiceCenterApp.Domain/Entities/Service.cs
namespace ServiceCenterApp.Domain.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
    }
}