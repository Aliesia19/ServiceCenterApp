using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Interfaces;
public class SendMessageValidator : IValidator<SendMessageCommand>
{
    public void Validate(SendMessageCommand command)
    {
        if (command.RequestId == Guid.Empty)
            throw new Exception("RequestId is required");

        if (command.SenderId == Guid.Empty)
            throw new Exception("SenderId is required");

        if (string.IsNullOrWhiteSpace(command.Message))
            throw new Exception("Message is required");
    }
}