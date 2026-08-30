using FluentValidation;
using Task10.Dtos;

namespace Task10.Validators
{
    public class UpdateTaskRequestValidator:AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskRequestValidator() 
        {
            RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Title is required.")
                    .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
                    .Must(NotContainHtmlTags).WithMessage("Title must not contain HTML tags.");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.UtcNow)
                .When(x => x.DueDate.HasValue)
                .WithMessage("Due date must be in the future.");
        }
        private bool NotContainHtmlTags(string title)
        {
            return !System.Text.RegularExpressions.Regex.IsMatch(title, "<.*?>");
        }
    }
}
