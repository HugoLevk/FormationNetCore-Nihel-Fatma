﻿using Microsoft.EntityFrameworkCore;
using Regies.Domain.Model;
using Regies.Domain.Repositories;
using Regies.Infrastructure.Persistence;

namespace Regies.Infrastructure.Repositories;

internal class RegieRepository(RegiesDBContext rDBContext) : IRegieRepository
{
    public async Task<IEnumerable<Regie>> GetAllAsync()
    {
        return await rDBContext.Regies.ToListAsync();
    }
    public async Task<Regie?> GetByIdAsync(int id)
    {
        return await rDBContext.Regies.FirstOrDefaultAsync( r => r.Id == id);
    }
}
