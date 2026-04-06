public class UpdateRequestStatusDto
{
    public Guid RequestId { get; set; }
    public string Status { get; set; } = string.Empty;
}