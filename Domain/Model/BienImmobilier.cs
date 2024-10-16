using System.Text.Json.Serialization;

namespace Regies.Domain.Model;

/// <summary>
/// Represents the type of real estate property.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TypeBien
{
    /// <summary>
    /// Represents an apartment.
    /// </summary>
    Appartement = 0,

    /// <summary>
    /// Represents a house.
    /// </summary>
    Maison = 1,

    /// <summary>
    /// Represents a land.
    /// </summary>
    Terrain = 2,

    /// <summary>
    /// Represents a building.
    /// </summary>
    Immeuble = 3,

    /// <summary>
    /// Represents an office.
    /// </summary>
    Bureau = 4,

    /// <summary>
    /// Represents a commercial space.
    /// </summary>
    LocalCommercial = 5,

    /// <summary>
    /// Represents a garage.
    /// </summary>
    Garage = 6,

    /// <summary>
    /// Represents another type of real estate property.
    /// </summary>
    Autre = 7
}

/// <summary>
/// Represents a real estate property.
/// </summary>
public class BienImmobilier
{
    /// <summary>
    /// Gets or sets the ID of the property.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the property listing.
    /// </summary>
    public string NomAnnonce { get; set; } = default!;

    /// <summary>
    /// Gets or sets the description of the property.
    /// </summary>
    public string Decription { get; set; } = default!;

    /// <summary>
    /// Gets or sets the address of the property.
    /// </summary>
    public Adresse Adresse { get; set; } = default!;

    /// <summary>
    /// Gets or sets a value indicating whether the property is for individuals (True) or for businesses (False).
    /// </summary>
    public bool pourParticulier { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the property is for rent (True) or for sale (False).
    /// </summary>
    public bool isLocation { get; set; }

    /// <summary>
    /// Gets or sets the rental price of the property.
    /// </summary>
    public decimal prixLocatif { get; set; }

    /// <summary>
    /// Gets or sets the sale price of the property.
    /// </summary>
    public decimal prixVente { get; set; }

    /// <summary>
    /// Gets or sets the year of construction of the property.
    /// </summary>
    public int? anneeCOnstruction { get; set; }

    /// <summary>
    /// Gets or sets the type of the property.
    /// </summary>
    public TypeBien _typeBien { get; set; } = TypeBien.Appartement;

    /// <summary>
    /// Gets or sets the ID of the real estate agency managing the property.
    /// </summary>
    public int RegieId { get; set; }
}
