using Regies.Domain.Model;

namespace Regies.Domain.Repositories;

/// <summary>
/// Interface for the BienImmoRepository.
/// </summary>
public interface IBienImmoRepository
{
    /// <summary>
    /// Gets all the BienImmobilier objects asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of BienImmobilier objects.</returns>
    public Task<IEnumerable<BienImmobilier>> GetAllAsync();

    /// <summary>
    /// Gets all the BienImmobilier objects associated with a specific regie asynchronously.
    /// </summary>
    /// <param name="regieId">The ID of the regie.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of BienImmobilier objects.</returns>
    public Task<IEnumerable<BienImmobilier>> GetAllByRegieAsync(int regieId);

    /// <summary>
    /// Gets a BienImmobilier object by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the BienImmobilier.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the BienImmobilier object, or null if not found.</returns>
    public Task<BienImmobilier?> GetByIdAsync(int id);

    /// <summary>
    /// Creates a new BienImmobilier object asynchronously.
    /// </summary>
    /// <param name="bienImmo">The BienImmobilier object to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the ID of the created BienImmobilier object.</returns>
    public Task<int> CreateAsync(BienImmobilier bienImmo);

    /// <summary>
    /// Updates an existing BienImmobilier object asynchronously.
    /// </summary>
    /// <param name="bienImmo">The BienImmobilier object to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task<bool> UpdateAsync(BienImmobilier bienImmo);

    /// <summary>
    /// Deletes a BienImmobilier object by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the BienImmobilier to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task<bool> DeleteAsync(BienImmobilier bienImmo);
}
