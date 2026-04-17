using ServiceCenterApp.Application.Commands;
using ServiceCenterApp.Application.Interfaces;

namespace ServiceCenterApp.Application.Validators
{
    public class AddChecklistItemValidator : IValidator<AddChecklistItemCommand>
    {
        public void Validate(AddChecklistItemCommand command)
        {
            if (command.RequestId == Guid.Empty)
                throw new Exception("RequestId is required");

            if (command.ServiceId == Guid.Empty)
                throw new Exception("ServiceId is required");

            if (command.Quantity <= 0)
                throw new Exception("Quantity must be greater than 0");
        }
    }
}