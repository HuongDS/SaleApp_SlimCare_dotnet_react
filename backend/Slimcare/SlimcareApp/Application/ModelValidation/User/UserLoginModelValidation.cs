using FluentValidation;
using SlimcareWeb.Service.Dtos.User;

namespace SlimcareApp.Application.ModelValidation.User
{
    public class UserLoginModelValidation : AbstractValidator<UserLoginDTO>
    {
        public UserLoginModelValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
        }
    }
}
