using FluentValidation;
using TT.GetGo.Web.Models;

namespace TT.GetGo.Web.Validator
{
    public class UserRequestValidator: AbstractValidator<UserRequest> 
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.X).NotNull().InclusiveBetween(-2147483647, 2147483647);
            RuleFor(x => x.Y).NotNull().InclusiveBetween(-2147483647, 2147483647);
        }
    }
}
