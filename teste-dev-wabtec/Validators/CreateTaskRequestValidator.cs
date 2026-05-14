using FluentValidation;
using teste_dev_wabtec.Api.DTOs;

namespace teste_dev_wabtec.Validators
{
    public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MinimumLength(3).WithMessage("O título deve ter no mínimo 3 caracteres.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");
        }
    }
}
