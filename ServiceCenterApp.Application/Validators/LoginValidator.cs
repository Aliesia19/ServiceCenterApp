using ServiceCenterApp.Application.Commands;

namespace ServiceCenterApp.Application.Validators
{
    public class LoginValidator
    {
        public void Validate(LoginCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Email))
                throw new Exception("Email is required");

            if (string.IsNullOrWhiteSpace(command.Password))
                throw new Exception("Password is required");
        }
    }
}