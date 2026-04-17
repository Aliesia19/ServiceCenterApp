using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Interfaces;

public class AssignMasterValidator : IValidator<AssignMasterCommand>
{
    public void Validate(AssignMasterCommand command)
    {
        if (command.RequestId == Guid.Empty)
            throw new Exception("RequestId is required");

        if (command.MasterId == Guid.Empty)
            throw new Exception("MasterId is required");
    }
}