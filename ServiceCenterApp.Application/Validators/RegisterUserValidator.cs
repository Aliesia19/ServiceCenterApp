using ServiceCenterApp.Application.Commands;

namespace ServiceCenterApp.Application.Validators
{
    public class RegisterUserValidator
    {
        public void Validate(RegisterUserCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.FullName))
                throw new Exception("Full name is required");

            if (string.IsNullOrWhiteSpace(command.Email))
                throw new Exception("Email is required");

            if (!command.Email.Contains("@"))
                throw new Exception("Invalid email format");

            if (string.IsNullOrWhiteSpace(command.Password))
                throw new Exception("Password is required");

            if (command.Password.Length < 6)
                throw new Exception("Password must be at least 6 characters");
        }
    }
}