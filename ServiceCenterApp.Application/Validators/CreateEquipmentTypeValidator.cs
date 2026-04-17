using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Interfaces;

public class CreateEquipmentTypeValidator : IValidator<CreateEquipmentTypeCommand>
{
    public void Validate(CreateEquipmentTypeCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Name))
            throw new Exception("Name is required");

        if (command.Name.Length < 2)
            throw new Exception("Name too short");
    }
}