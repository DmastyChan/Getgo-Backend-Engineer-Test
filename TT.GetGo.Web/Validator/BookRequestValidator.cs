using FluentValidation;
using TT.GetGo.Web.Models;

namespace TT.GetGo.Web.Validator
{
    public class BookRequestValidator: AbstractValidator<BookRequest> 
    {
        public BookRequestValidator()
        {
            RuleFor(z => z.CarId).NotNull().GreaterThan(0);
            RuleFor(z => z.User).SetValidator(new UserRequestValidator());
        }
    }
}
