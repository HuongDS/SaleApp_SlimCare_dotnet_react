using FluentValidation;
using SlimcareWeb.Service.Dtos.User;

namespace SlimcareApp.Application.ModelValidation.User
{
    public class UserCreateModelValidation : AbstractValidator<CreateUserDto>
    {
        public UserCreateModelValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("This field is required.");
            RuleFor(x => x.Username).Length(6, 50).WithMessage("Username must be between 6 and 50 characters long.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("This field is required.");
            RuleFor(x => x.Password).Length(6, 100).WithMessage("Password must be between 6 and 100 characters long.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$")
                .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one number.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("This field is required.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
