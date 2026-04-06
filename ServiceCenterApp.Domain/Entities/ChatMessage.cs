// ServiceCenterApp.Domain/Entities/ChatMessage.cs
namespace ServiceCenterApp.Domain.Entities
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public Guid RepairRequestId { get; set; }
        public RepairRequest RepairRequest { get; set; } = null!;
        public Guid SenderId { get; set; }
        public User Sender { get; set; } = null!;
        public string Message { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}