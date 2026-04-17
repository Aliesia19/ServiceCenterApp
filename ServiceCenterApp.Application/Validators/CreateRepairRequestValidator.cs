using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Interfaces;

public class CreateRepairRequestValidator : IValidator<CreateRepairRequestCommand>
{
    public void Validate(CreateRepairRequestCommand command)
    {
        if (command.ClientId == Guid.Empty)
            throw new Exception("ClientId is required");

        if (command.EquipmentTypeId == Guid.Empty)
            throw new Exception("EquipmentTypeId is required");

        if (string.IsNullOrWhiteSpace(command.Description))
            throw new Exception("Description is required");

        if (string.IsNullOrWhiteSpace(command.City))
            throw new Exception("City is required");

        if (string.IsNullOrWhiteSpace(command.Street))
            throw new Exception("Street is required");
    }
}