using Regies.Application.Regies.DTOs;
using Regies.Domain.Model;
using Regies.Domain.Repositories;

namespace Regies.Application.Regies;

public class RegieService(IRegieRepository regieRepository) : IRegieService
{
    public async Task<IEnumerable<RegieDto?>> GetAllRegies()
    {
        var regies = await regieRepository.GetAllAsync();
        return regies.Select(r => RegieDto.FromRegie(r));
    }

    public async Task<RegieDto?> GetRegieById(int id)
    {
        var regie = await regieRepository.GetByIdAsync(id);
        RegieDto? regieDto = RegieDto.FromRegie(regie);
        return regieDto;
    }

}
