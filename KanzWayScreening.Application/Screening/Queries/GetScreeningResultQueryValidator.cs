using FluentValidation;

namespace KanzWayScreening.Application.Screening.Queries
{
    public class GetScreeningResultQueryValidator : AbstractValidator<GetScreeningResultQuery>
    {
        public GetScreeningResultQueryValidator()
        {
            RuleFor(r => r.Number)
                .NotNull()
                .WithMessage("Number cannot be null.")
                .Must(BeAValidNumber)
                .WithMessage("Input must be a valid number.");
        }

        private bool BeAValidNumber(int input)
        {
            return input >= int.MinValue && input <= int.MaxValue;
        }
    }
}
