using Microsoft.EntityFrameworkCore;
using Regies.Domain.Model;
using Regies.Domain.Repositories;
using Regies.Infrastructure.Persistence;

namespace Regies.Infrastructure.Repositories;

/// <summary>
/// Represents a repository for managing real estate properties.
/// </summary>
public class BienImmoRepository(RegiesDBContext dbContext) : IBienImmoRepository
{
    /// <summary>
    /// Creates a new real estate property asynchronously.
    /// </summary>
    /// <param name="bienImmo">The real estate property to create.</param>
    /// <returns>The task representing the asynchronous operation.</returns>
    public async Task<int> CreateAsync(BienImmobilier bienImmo)
    {
        dbContext.BienImmobiliers.Add(bienImmo);
        await dbContext.SaveChangesAsync();
        return bienImmo.Id;
    }

    /// <summary>
    /// Deletes a real estate property asynchronously.
    /// </summary>
    /// <param name="id">The ID of the real estate property to delete.</param>
    /// <returns>The task representing the asynchronous operation.</returns>
    public async Task<bool> DeleteAsync(BienImmobilier bienImmo)
    {
        dbContext.BienImmobiliers.Remove(bienImmo);
        await dbContext.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Gets all real estate properties asynchronously.
    /// </summary>
    /// <returns>The task representing the asynchronous operation.</returns>
    public async Task<IEnumerable<BienImmobilier>> GetAllAsync()
    {
        var bienImmos = await dbContext.BienImmobiliers.ToListAsync();
        return bienImmos;
    }

    public async Task<IEnumerable<BienImmobilier>> GetAllFromRegieAsync(int _regieId)
    {
        var bienImmos = await dbContext.BienImmobiliers.Where(bi => bi.RegieId == _regieId).ToListAsync();
        return bienImmos;
    }

    /// <summary>
    /// Gets all real estate properties associated with a specific regie asynchronously.
    /// </summary>
    /// <param name="regieId">The ID of the regie.</param>
    /// <returns>The task representing the asynchronous operation.</returns>
    public async Task<IEnumerable<BienImmobilier>> GetAllByRegieAsync(int regieId)
    {
        var bienImmos = await dbContext.BienImmobiliers.Where(b => b.RegieId == regieId).ToListAsync();
        return bienImmos;
    }

    /// <summary>
    /// Gets a real estate property by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the real estate property.</param>
    /// <returns>The task representing the asynchronous operation.</returns>
    public async Task<BienImmobilier?> GetByIdAsync(int id)
    {
       var bienImmo = await dbContext.BienImmobiliers.FindAsync(id);
        return bienImmo;
    }

    /// <summary>
    /// Updates a real estate property asynchronously.
    /// </summary>
    /// <param name="bienImmo">The real estate property to update.</param>
    /// <returns>The task representing the asynchronous operation.</returns>
    public async Task<bool> UpdateAsync(BienImmobilier bienImmo)
    {
        dbContext.BienImmobiliers.Update(bienImmo);
        await dbContext.SaveChangesAsync();
        return true;
    }
}
