namespace Regies.Domain.Model;

/// <summary>
/// Représente une adresse.
/// </summary>
public class Adresse
{
    /// <summary>
    /// Obtient ou définit la ville de l'adresse.
    /// </summary>
    public string? Ville { get; set; }

    /// <summary>
    /// Obtient ou définit le numéro de rue de l'adresse.
    /// </summary>
    public string? numeroRue { get; set; }

    /// <summary>
    /// Obtient ou définit le nom de la rue de l'adresse.
    /// </summary>
    public string? Rue { get; set; }

    /// <summary>
    /// Obtient ou définit le code postal de l'adresse.
    /// </summary>
    public string? codePostal { get; set; }
}
