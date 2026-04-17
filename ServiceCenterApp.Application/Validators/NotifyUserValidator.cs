using ServiceCenterApp.Application.Commands;

public class NotifyUserValidator
{
    public void Validate(NotifyUserCommand command)
    {
        if (command.UserId == Guid.Empty)
            throw new Exception("UserId is required");

        if (string.IsNullOrWhiteSpace(command.Message))
            throw new Exception("Message is required");
    }
}