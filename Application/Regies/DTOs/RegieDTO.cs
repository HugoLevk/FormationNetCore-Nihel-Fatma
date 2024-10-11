using Regies.Domain.Model;

namespace Regies.Application.Regies.DTOs;

public class RegieDto
{
    public int Id { get; set;  }
    public string Nom { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool estActive { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? StreetNumber { get; set; }
    public string? ZipCode { get; set; }
    public List<BienImmobilier> lesBiensDeLaRegie { get; set; } = [];

}
