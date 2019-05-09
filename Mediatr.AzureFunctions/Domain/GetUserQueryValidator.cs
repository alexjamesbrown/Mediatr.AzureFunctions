using FluentValidation;

namespace Mediatr.AzureFunctions.Domain
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name must be specified")

                .Length(5, 10)
                .WithMessage("Name must be between 5 and 10 chars");
        }
    }
}
