// ServiceCenterApp.Domain/Entities/RepairRequest.cs
using ServiceCenterApp.Domain.Enums;
namespace ServiceCenterApp.Domain.Entities
{
    public class RepairRequest
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public User Client { get; set; } = null!;
        public Guid? MasterId { get; set; }
        public User? Master { get; set; }
        public Guid ConsultantId { get; set; }
        public User Consultant { get; set; } = null!;
        public EquipmentType EquipmentType { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<ChecklistItem> Checklist { get; set; } = new();
        public decimal TotalPrice { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
    }
}