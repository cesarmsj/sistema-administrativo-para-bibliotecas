using FluentValidation;

namespace Novateca.Web.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Informe o e-mail")
                .EmailAddress().WithMessage("E-mail inválido");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Informe a senha")
                .Length(8, 20).WithMessage("A senha deve ter entre 8 a 16 caracteres");
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("As senhas não conferem");
            
        }

    }
}
