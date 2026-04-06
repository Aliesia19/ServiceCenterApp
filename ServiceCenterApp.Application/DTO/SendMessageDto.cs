public class SendMessageDto
{
    public Guid RequestId { get; set; }
    public Guid SenderId { get; set; }
    public string Message { get; set; } = string.Empty;
}