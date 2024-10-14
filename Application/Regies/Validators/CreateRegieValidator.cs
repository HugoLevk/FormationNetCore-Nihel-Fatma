using FluentValidation;
using Regies.Application.Regies.Commands.CreateRegie;
using Regies.Application.Regies.DTOs;

namespace Regies.Application.Regies.Validators;

/// <summary>
/// Validator for creating a regie.
/// </summary>
public class CreateRegieValidator : AbstractValidator<CreateRegieCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateRegieValidator"/> class.
    /// </summary>
    public CreateRegieValidator()
    {
        RuleFor(r => r.Nom)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100)
            .WithErrorCode("1001")
            .WithMessage("Le Nom doit comprendre entre 3 et 100 caractères.");

        RuleFor(r => r.Description)
            .NotEmpty()
            .WithErrorCode("1002")
            .WithMessage("La Description est obligatoire.");

        RuleFor(r => r.contactEmail)
            .EmailAddress()
            .WithErrorCode("1003")
            .WithMessage("Fournissez une adresse mail valide.");

        RuleFor(r => r.contactTelephone)
            .Matches(@"^\d{9}$")
            .WithErrorCode("1004")
            .WithMessage("Le Numéro de téléphone n'est pas valide");

        RuleFor(r => r.ZipCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithErrorCode("1005")
            .WithMessage("Le Code postal n'est pas valide (XX-XXX).");
    }
}
