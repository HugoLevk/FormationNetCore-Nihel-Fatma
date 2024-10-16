using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Application.BienImmobiliers.DTOs;
using Regies.Domain.Repositories;

namespace Regies.Application.BienImmobiliers.Querys.GetAllBienImmo;

/// <summary>
/// Handles the query to get all the real estate properties.
/// </summary>
public class GetAllBienImmoQueryHandler(ILogger<GetAllBienImmoQueryHandler> logger, IBienImmoRepository bienImmoRepository, IMapper mapper) : IRequestHandler<GetAllBienImmoQuery, IEnumerable<BienImmobiliersDTOs>>
{

    /// <summary>
    /// Handles the query to get all the real estate properties.
    /// </summary>
    /// <param name="request">The query request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The collection of real estate properties DTOs.</returns>
    public async Task<IEnumerable<BienImmobiliersDTOs>> Handle(GetAllBienImmoQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetAllBienImmoQueryHandler.Handle");
        var biensImmo = await bienImmoRepository.GetAllAsync();

        var biensImmoDTOs = mapper.Map<IEnumerable<BienImmobiliersDTOs>>(biensImmo);

        return biensImmoDTOs;
    }
}
