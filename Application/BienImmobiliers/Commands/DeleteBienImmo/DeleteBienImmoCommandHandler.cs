using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Domain.Exceptions;
using Regies.Domain.Repositories;

namespace Regies.Application.BienImmobiliers.Commands.DeleteBienImmo;

/// <summary>
/// Handles the command to delete a real estate property.
/// </summary>
public class DeleteBienImmoCommandHandler(ILogger<DeleteBienImmoCommandHandler> logger, IBienImmoRepository bienImmoRepository) : IRequestHandler<DeleteBienImmoCommand, bool>
{
    /// <summary>
    /// Handles the delete real estate property command.
    /// </summary>
    /// <param name="request">The delete real estate property command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A boolean indicating whether the deletion was successful or not.</returns>
    public async Task<bool> Handle(DeleteBienImmoCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Delete Bien Immo with Id : {Id}", request.Id);

        var bienImmo = await bienImmoRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Bien Immobilier", request.Id.ToString());

        return await bienImmoRepository.DeleteAsync(bienImmo);
    }
}
