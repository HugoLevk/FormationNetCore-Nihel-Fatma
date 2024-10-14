using MediatR;

namespace Regies.Application.Regies.Commands.CreateRegie;

/// <summary>
/// Commande pour créer une régie.
/// </summary>
public class CreateRegieCommand : IRequest<int>
{
    /// <summary>
    /// Obtient ou définit le nom de la régie.
    /// </summary>
    public string Nom { get; set; } = default!;

    /// <summary>
    /// Obtient ou définit la description de la régie.
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Obtient ou définit une valeur indiquant si la régie est active.
    /// </summary>
    public bool estActive { get; set; }

    /// <summary>
    /// Obtient ou définit l'adresse e-mail de contact de la régie.
    /// </summary>
    public string? contactEmail { get; set; }

    /// <summary>
    /// Obtient ou définit le numéro de téléphone de contact de la régie.
    /// </summary>
    public string? contactTelephone { get; set; }

    /// <summary>
    /// Obtient ou définit la ville de la régie.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Obtient ou définit la rue de la régie.
    /// </summary>
    public string? Street { get; set; }

    /// <summary>
    /// Obtient ou définit le numéro de rue de la régie.
    /// </summary>
    public string? StreetNumber { get; set; }

    /// <summary>
    /// Obtient ou définit le code postal de la régie.
    /// </summary>
    public string? ZipCode { get; set; }
}
