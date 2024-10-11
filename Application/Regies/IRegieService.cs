using Regies.Application.Regies.Commands.CreateRegie;
using Regies.Application.Regies.DTOs;
using Regies.Domain.Model;

namespace Regies.Application.Regies;

public interface IRegieService
{
    Task<IEnumerable<RegieDto>> GetAllRegies();
    Task<RegieDto> GetRegieById(int id);
}