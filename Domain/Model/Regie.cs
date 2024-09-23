namespace Regies.Domain.Model;

public class Regie
{
    public int Id { get; set; }

    public string Nom { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool estActive { get; set; }

    public string? contactEmail { get; set; }
    public string? contactTelephone {  get; set; }

    public Adresse? Adresse { get; set; }

    public List<BienImmobilier> lesBiensDeLaRegie { get; set; } = [];

}
