using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Interfaces;

public class DeleteServiceValidator : IValidator<DeleteServiceCommand>
{
    public void Validate(DeleteServiceCommand command)
    {
        if (command.Id == Guid.Empty)
            throw new Exception("Id is required");
    }
}