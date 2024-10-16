using MediatR;

namespace Regies.Application.BienImmobiliers.Commands.UpdateBienImmo;

/// <summary>
/// Représente une commande pour mettre à jour un bien immobilier.
/// </summary>
public class UpdateBienImmoCommand : IRequest
{
    /// <summary>
    /// Obtient ou définit l'identifiant du bien immobilier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtient ou définit la description du bien immobilier.
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Obtient ou définit la rue du bien immobilier.
    /// </summary>
    public string Rue { get; set; } = default!;

    /// <summary>
    /// Obtient ou définit la ville du bien immobilier.
    /// </summary>
    public string Ville { get; set; } = default!;

    /// <summary>
    /// Obtient ou définit le code postal du bien immobilier.
    /// </summary>
    public string CodePostal { get; set; } = default!;

    /// <summary>
    /// Obtient ou définit le numéro de rue du bien immobilier.
    /// </summary>
    public string NumeroRue { get; set; } = default!;
}
