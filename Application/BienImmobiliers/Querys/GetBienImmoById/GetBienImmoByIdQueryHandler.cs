using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Application.BienImmobiliers.DTOs;
using Regies.Domain.Exceptions;
using Regies.Domain.Repositories;

namespace Regies.Application.BienImmobiliers.Querys.GetBienImmoById;

/// <summary>
/// Handles the query to get a real estate property by its ID.
/// </summary>
public class GetBienImmoByIdQueryHandler(ILogger<GetBienImmoByIdQueryHandler> logger, IMapper mapper, IBienImmoRepository bienImmoRepository) : IRequestHandler<GetBienImmoByIdQuery, BienImmobiliersDTOs>
{ 

    /// <summary>
    /// Handles the query to get a real estate property by its ID.
    /// </summary>
    /// <param name="request">The query request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The real estate property DTO.</returns>
    public async Task<BienImmobiliersDTOs> Handle(GetBienImmoByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get Bien Immo by Id : {Id}", request.Id);
        var bienImmo = await bienImmoRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Bien Immobilier", request.Id.ToString());

        var bienImmoDTO = mapper.Map<BienImmobiliersDTOs>(bienImmo);

        return bienImmoDTO;
    }
}
