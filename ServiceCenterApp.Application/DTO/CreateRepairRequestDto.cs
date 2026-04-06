public class CreateRepairRequestDto
{
    public Guid ClientId { get; set; }
    public Guid EquipmentTypeId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;

    public string ServiceFormat { get; set; } = string.Empty;
}