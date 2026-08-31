using Task10.Dtos;
using FluentValidation;

namespace Task10.Validators
{
    public class CreateTaskRequestValidator: AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskRequestValidator() 
        {
            RuleFor(x => x.Title).NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(200)
                .WithMessage("Title must not exceed 200 characters.")
                .Must(name=>(!name.Contains(">")&&!name.Contains("<") && !name.Contains("?"))).WithMessage("Title must not contain HTML tags.");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.UtcNow)
                .When(x => x.DueDate.HasValue)
                .WithMessage("Due date must be in the future.");

        }


        
    }
}
