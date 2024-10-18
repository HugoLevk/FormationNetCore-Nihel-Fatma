namespace Regies.Domain.Model;

/// <summary>
/// Représente une régie.
/// </summary>
public class Regie
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
    /// Obtient ou définit l'adresse e-mail de contact de la régie.
    /// </summary>
    public string? contactEmail { get; set; }

    /// <summary>
    /// Obtient ou définit le numéro de téléphone de contact de la régie.
    /// </summary>
    public string? contactTelephone { get; set; }

    /// <summary>
    /// Obtient ou définit l'adresse de la régie.
    /// </summary>
    public Adresse Adresse { get; set; } = default!;

    /// <summary>
    /// Obtient ou définit la liste des biens immobiliers de la régie.
    /// </summary>
    public List<BienImmobilier> lesBiensDeLaRegie { get; set; } = [];

    /// <summary>
    /// Obtient ou définit le propriétaire de la régie.
    /// </summary>
    public User Owner { get; set; } = default!;

    /// <summary>
    /// Obtient ou définit l'identifiant du propriétaire de la régie.
    /// </summary>
    public string OwnerId { get; set; } = default!;
}
