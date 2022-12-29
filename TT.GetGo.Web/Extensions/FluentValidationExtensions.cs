using FluentValidation.Results;

namespace TT.GetGo.Web.Extensions
{
    public static class FluentValidationExtensions
    {
        /// <summary>
        /// Convert the validation result into dictionary
        /// </summary>
        /// <param name="validationResult"></param>
        /// <returns></returns>
        public static IDictionary<string, string[]> ToErrorDictionary(this ValidationResult validationResult)
        {
            return validationResult.Errors
                .GroupBy(x => x.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.ErrorMessage).ToArray()
                );
        }
    }
}
