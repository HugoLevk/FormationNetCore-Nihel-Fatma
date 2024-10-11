using AutoMapper;
using Regies.Application.Regies.DTOs;
using Regies.Domain.Model;
using Regies.Domain.Repositories;

namespace Regies.Application.Regies;

public class RegieService(IRegieRepository regieRepository, IMapper mapper) : IRegieService
{
    public async Task<IEnumerable<RegieDto>> GetAllRegies()
    {
        var regies = await regieRepository.GetAllAsync();
        var regiesDtos = mapper.Map<IEnumerable<RegieDto>>(regies);
        return regiesDtos;
    }

    public async Task<RegieDto?> GetRegieById(int id)
    {
        var regie = await regieRepository.GetByIdAsync(id);
        RegieDto? regieDto = mapper.Map<RegieDto>(regie);
        return regieDto;
    }

}
