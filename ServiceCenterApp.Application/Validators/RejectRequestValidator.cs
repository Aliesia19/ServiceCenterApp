using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Interfaces;

public class RejectRequestValidator : IValidator<RejectRequestCommand>
{
    public void Validate(RejectRequestCommand command)
    {
        if (command.RequestId == Guid.Empty)
            throw new Exception("RequestId is required");

        if (string.IsNullOrWhiteSpace(command.Reason))
            throw new Exception("Reason is required");
    }
}