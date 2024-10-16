using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Domain.Exceptions;
using Regies.Domain.Repositories;

namespace Regies.Application.BienImmobiliers.Commands.UpdateBienImmo;

/// <summary>
/// Handles the command to update a real estate property.
/// </summary>
public class UpdateBienImmoCommandHandler(ILogger<UpdateBienImmoCommandHandler> logger, IMapper mapper, IBienImmoRepository bienImmoRepository, IRegieRepository regieRepository) : IRequestHandler<UpdateBienImmoCommand>
{
    /// <summary>
    /// Handles the update real estate property command.
    /// </summary>
    /// <param name="request">The update real estate property command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(UpdateBienImmoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating real estate property with ID {@Id}.", request.Id);

        var bienImmo = await bienImmoRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Real estate property", request.Id.ToString());
        
        _ = await regieRepository.GetByIdAsync(bienImmo.RegieId) ?? throw new NotFoundException("Régie", request.Id.ToString());

        mapper.Map(request, bienImmo);

        await bienImmoRepository.UpdateAsync(bienImmo);
    }
}
