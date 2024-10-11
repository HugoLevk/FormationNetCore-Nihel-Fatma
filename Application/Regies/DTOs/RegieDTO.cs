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

    public static RegieDto? FromRegie(Regie? regie)
    {
        if (regie == null) return null;
        return new RegieDto
        {
            Id = regie.Id,
            Nom = regie.Nom,
            Description = regie.Description,
            estActive = regie.estActive,
            Adresse = regie.Adresse,
            lesBiensDeLaRegie = regie.lesBiensDeLaRegie
        };
    }

    public static Regie? FromDto(RegieDto? regieDto)
    {
        if (regieDto == null) return null;
        return new Regie
        {
            Id = regieDto.Id,
            Nom = regieDto.Nom,
            Description = regieDto.Description,
            estActive = regieDto.estActive,
            Adresse = regieDto.Adresse,
            lesBiensDeLaRegie = regieDto.lesBiensDeLaRegie
        };
    }

}
