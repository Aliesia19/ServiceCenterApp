// ServiceCenterApp.Domain/Entities/ChecklistItem.cs
namespace ServiceCenterApp.Domain.Entities
{
    public class ChecklistItem
    {
        public Guid Id { get; set; }
        public Guid RepairRequestId { get; set; }
        public RepairRequest RepairRequest { get; set; } = null!;
        public Guid ServiceId { get; set; }
        public Service Service { get; set; } = null!;
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
    }
}