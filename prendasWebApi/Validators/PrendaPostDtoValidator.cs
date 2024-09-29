using FluentValidation;
using prendasWebApi.Dtos;

namespace prendasWebApi.Validators
{
    public class PrendaPostDtoValidator : AbstractValidator<PrendaPostDto>
    {
        public PrendaPostDtoValidator()
        {
            RuleFor(x => x.nombrepost)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5).WithMessage("Minimo 5 Caracteres");
            RuleFor(x => x.tallepost)
                .NotEmpty()
                .NotNull()
                .MaximumLength(5).WithMessage("Largo maximo 5");
            RuleFor(x => x.colorpost)
                .NotEmpty();
            RuleFor(x => x.id_marca)
                .NotEmpty();
        }
    }
}
