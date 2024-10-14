using Regies.Domain.Model;

namespace Regies.Application.BienImmobiliers.DTOs;

/// <summary>
/// Représente un bien immobilier.
/// </summary>
public class BienImmobiliersDTOs
{
    /// <summary>
    /// Obtient ou définit le nom de l'annonce.
    /// </summary>
    public string NomAnnonce { get; set; } = default!;

    /// <summary>
    /// Obtient ou définit la description du bien immobilier.
    /// </summary>
    public string Decription { get; set; } = default!;

    /// <summary>
    /// Obtient ou définit l'adresse du bien immobilier.
    /// </summary>
    public Adresse Adresse { get; set; } = default!;

    /// <summary>
    /// Obtient ou définit une valeur indiquant si le bien immobilier est destiné aux particuliers.
    /// </summary>
    /// <remarks>
    /// True: C'est à destination de particuliers, False à destination d'entreprises.
    /// </remarks>
    public bool pourParticulier { get; set; }

    /// <summary>
    /// Obtient ou définit une valeur indiquant si le bien immobilier est une location.
    /// </summary>
    public bool isLocation { get; set; }

    /// <summary>
    /// Obtient ou définit le prix locatif du bien immobilier.
    /// </summary>
    public decimal prixLocatif { get; set; }

    /// <summary>
    /// Obtient ou définit le prix de vente du bien immobilier.
    /// </summary>
    public decimal prixVente { get; set; }

    /// <summary>
    /// Obtient ou définit l'année de construction du bien immobilier.
    /// </summary>
    public int? anneeCOnstruction { get; set; }

    /// <summary>
    /// Obtient ou définit le type de bien immobilier.
    /// </summary>
    public TypeBien _typeBien { get; set; } = TypeBien.Appartement;
}
