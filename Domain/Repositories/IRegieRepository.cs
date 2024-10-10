using Regies.Domain.Model;

namespace Regies.Domain.Repositories;

public interface IRegieRepository
{
    Task<IEnumerable<Regie>> GetAllAsync();
    Task<Regie> GetByIdAsync(int id);
}
