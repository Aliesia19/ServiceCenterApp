using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Interfaces;

public class UpdateServiceValidator : IValidator<UpdateServiceCommand>
{
    public void Validate(UpdateServiceCommand command)
    {
        if (command.Id == Guid.Empty)
            throw new Exception("Id is required");

        if (string.IsNullOrWhiteSpace(command.Name))
            throw new Exception("Name is required");

        if (command.BasePrice < 0)
            throw new Exception("Price cannot be negative");
    }
}