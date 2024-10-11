using Regies.Application.Regies.DTOs;
using Regies.Domain.Model;
using Regies.Domain.Repositories;

namespace Regies.Application.Regies;

public class RegieService(IRegieRepository regieRepository) : IRegieService
{
    public async Task<IEnumerable<RegieDto>> GetAllRegies()
    {
        var regies = await regieRepository.GetAllAsync();
        return regies.Select(r => new RegieDto
        {
            Id = r.Id,
            Nom = r.Nom,
            Description = r.Description,
            estActive = r.estActive,
            Adresse = r.Adresse,
            lesBiensDeLaRegie = r.lesBiensDeLaRegie
        });
    }

    public async Task<RegieDto?> GetRegieById(int id)
    {
        var regie = await regieRepository.GetByIdAsync(id);
        RegieDto? regieDto = null;

        if (regie != null)
        {
            regieDto = new RegieDto
            {
                Id = regie.Id,
                Nom = regie.Nom,
                Description = regie.Description,
                estActive = regie.estActive,
                Adresse = regie.Adresse,
                lesBiensDeLaRegie = regie.lesBiensDeLaRegie
            };
        }
        return regieDto;
    }

}
