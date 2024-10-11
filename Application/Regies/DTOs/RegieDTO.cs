using Regies.Domain.Model;

namespace Regies.Application.Regies.DTOs;

public class RegieDto
{
    public int Id { get; set;  }
    public string Nom { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool estActive { get; set; }
    public Adresse Adresse { get; set; } = default!;
    public List<BienImmobilier> lesBiensDeLaRegie { get; set; } = [];

}
