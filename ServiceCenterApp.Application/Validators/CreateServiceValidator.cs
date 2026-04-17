using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Interfaces;

public class CreateServiceValidator : IValidator<CreateServiceCommand>
{
    public void Validate(CreateServiceCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Name))
            throw new Exception("Name is required");

        if (command.BasePrice < 0)
            throw new Exception("Price cannot be negative");
    }
}