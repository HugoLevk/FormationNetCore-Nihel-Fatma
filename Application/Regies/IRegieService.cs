using Regies.Domain.Model;

namespace Regies.Application.Regies;

public interface IRegieService
{
    Task<IEnumerable<Regie>> GetAllRegies();
    Task<Regie> GetRegieById(int id);
}