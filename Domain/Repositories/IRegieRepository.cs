using Regies.Domain.Model;

namespace Regies.Domain.Repositories;

/// <summary>
/// Represents a repository for managing Regie entities.
/// </summary>
public interface IRegieRepository
{
    /// <summary>
    /// Retrieves all Regie entities asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of Regie entities.</returns>
    Task<IEnumerable<Regie>> GetAllAsync();

    /// <summary>
    /// Retrieves a Regie entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the Regie entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the Regie entity.</returns>
    Task<Regie?> GetByIdAsync(int id);

    /// <summary>
    /// Creates a new Regie entity asynchronously.
    /// </summary>
    /// <param name="regie">The Regie entity to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the ID of the created Regie entity.</returns>
    Task<int> CreateAsync(Regie regie);

    /// <summary>
    /// Updates an existing Regie entity asynchronously.
    /// </summary>
    /// <param name="regie">The Regie entity to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateAsync(Regie regie);
}
