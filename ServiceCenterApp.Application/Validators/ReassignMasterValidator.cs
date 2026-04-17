using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Interfaces;

public class ReassignMasterValidator : IValidator<ReassignMasterCommand>
{
    public void Validate(ReassignMasterCommand command)
    {
        if (command.RequestId == Guid.Empty)
            throw new Exception("RequestId is required");

        if (command.NewMasterId == Guid.Empty)
            throw new Exception("NewMasterId is required");
    }
}