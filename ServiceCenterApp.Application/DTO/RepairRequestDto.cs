public class RepairRequestDto
{
    public Guid Id { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string EquipmentType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}