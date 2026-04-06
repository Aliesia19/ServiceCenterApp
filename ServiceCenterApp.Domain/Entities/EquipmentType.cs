// ServiceCenterApp.Domain/Entities/EquipmentType.cs
namespace ServiceCenterApp.Domain.Entities
{
    public class EquipmentType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}