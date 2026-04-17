using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Interfaces;
public class CompleteRequestValidator : IValidator<CompleteRequestCommand>
{
    public void Validate(CompleteRequestCommand command)
    {
        if (command.RequestId == Guid.Empty)
            throw new Exception("RequestId is required");
    }
}