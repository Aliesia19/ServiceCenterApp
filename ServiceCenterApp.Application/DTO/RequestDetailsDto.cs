public class RequestDetailsDto
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;

    public string ClientName { get; set; } = string.Empty;
    public string MasterName { get; set; } = string.Empty;

    public List<ChecklistItemDto> Checklist { get; set; } = new();
}