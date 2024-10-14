using Regies.Domain.Model;

namespace Regies.Application.Regies.DTOs;

/// <summary>
/// Représente un DTO pour une régie.
/// </summary>
public class RegieDto
{
    /// <summary>
    /// Obtient ou définit l'identifiant de la régie.
    /// </summary>
    public int Id { get; set; }

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

    /// <summary>
    /// Obtient ou définit la liste des biens immobiliers de la régie.
    /// </summary>
    public List<BienImmobilier> lesBiensDeLaRegie { get; set; } = new List<BienImmobilier>();
}
