using FluentValidation;
using TT.GetGo.Web.Models;

namespace TT.GetGo.Web.Validator
{
    public class SearchRequestValidator: AbstractValidator<SearchRequest> 
    {
        public SearchRequestValidator()
        {
            RuleFor(z => z.SearchKeyWords).MaximumLength(300);
            RuleFor(z => z.User).SetValidator(new UserRequestValidator());
        }
    }
}