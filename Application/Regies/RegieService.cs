﻿using Regies.Domain.Model;
using Regies.Domain.Repositories;

namespace Regies.Application.Regies;

public class RegieService(IRegieRepository regieRepository) : IRegieService
{
    public async Task<IEnumerable<Regie>> GetAllRegies()
    {
        return await regieRepository.GetAllAsync();
    }

    public async Task<Regie> GetRegieById(int id)
    {
        return await regieRepository.GetByIdAsync(id);
    }

}
