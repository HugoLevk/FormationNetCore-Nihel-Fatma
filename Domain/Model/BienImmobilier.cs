namespace Regies.Domain.Model;

public enum TypeBien
{
    Appartement,
    Maison,
    Terrain,
    Immeuble,
    Bureau,
    LocalCommercial,
    Garage,
    Autre
}

public class BienImmobilier
{
    public Guid Id { get; set; }
    public string NomAnnonce { get; set; } = default!;
    public string Decription { get; set; } = default!;

    public Adresse Adresse { get; set; } = default!;

    /// <summary>
    /// True: C'est à destiantion de particuliers, False à destination d'entreprises
    /// </summary>
    public bool pourParticulier { get; set; }
    public bool isLocation { get; set; }

    public decimal prixLocatif {  get; set; }
    public decimal prixVente { get; set; }

    public int? anneeCOnstruction { get; set; }
    public TypeBien _typeBien { get; set; } = TypeBien.Appartement;

    public int RegieId { get; set; }
}
