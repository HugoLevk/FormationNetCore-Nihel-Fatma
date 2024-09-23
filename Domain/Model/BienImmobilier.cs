﻿namespace Regies.Domain.Model;

public class BienImmobilier
{
    Guid Id { get; set; }
    public string NomAnnonce { get; set; } = default!;
    public string Decription { get; set; } = default!;

    /// <summary>
    /// True: C'est à destiantion de particuliers, False à destination d'entreprises
    /// </summary>
    public bool pourParticulier { get; set; }
    public bool isLocation { get; set; }

    public decimal prixLocatif {  get; set; }
    public decimal prixVente { get; set; }
}
