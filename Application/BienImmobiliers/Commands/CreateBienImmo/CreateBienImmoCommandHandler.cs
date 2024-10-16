using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Domain.Exceptions;
using Regies.Domain.Model;
using Regies.Domain.Repositories;

namespace Regies.Application.BienImmobiliers.Commands.CreateBienImmo;

/// <summary>
/// Handles the command to create a real estate property.
/// </summary>
public class CreateBienImmoCommandHandler(ILogger<CreateBienImmoCommandHandler> logger, IMapper mapper, IBienImmoRepository bienImmoRepository, IRegieRepository regieRepository) : IRequestHandler<CreateBienImmoCommand, int>
{
    /// <summary>
    /// Handles the creation of a real estate property.
    /// </summary>
    /// <param name="request">The command to create a real estate property.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The ID of the created real estate property.</returns>
    public async Task<int> Handle(CreateBienImmoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating real estate property with name {@Nom}.", request.NomAnnonce);

        var Regie = await regieRepository.GetByIdAsync(request.RegieId) ?? throw new NotFoundException("Régie", request.RegieId.ToString());

        var bienImmo = mapper.Map<BienImmobilier>(request);

        return await bienImmoRepository.CreateAsync(bienImmo);
    }
}
