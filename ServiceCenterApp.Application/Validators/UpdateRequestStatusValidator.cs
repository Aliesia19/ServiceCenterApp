using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Domain.Enums;
using ServiceCenterApp.Application.Interfaces;

public class UpdateRequestStatusValidator : IValidator<UpdateRequestStatusCommand>
{
    public void Validate(UpdateRequestStatusCommand command)
    {
        if (command.RequestId == Guid.Empty)
            throw new Exception("RequestId is required");

        if (!Enum.TryParse<RequestStatus>(command.Status, out _))
            throw new Exception("Invalid status");
    }
}