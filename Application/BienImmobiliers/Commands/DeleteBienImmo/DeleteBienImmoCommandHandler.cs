using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Domain.Exceptions;
using Regies.Domain.Repositories;

namespace Regies.Application.BienImmobiliers.Commands.DeleteBienImmo;

public class DeleteBienImmoCommandHandler(ILogger<DeleteBienImmoCommandHandler> logger, IBienImmoRepository bienImmoRepository, IRegieRepository regieRepository) : IRequestHandler<DeleteBienImmoCommand, bool>
{
    public async Task<bool> Handle(DeleteBienImmoCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Delete Bien Immo with Id : {Id}", request.Id);

        var bienImmo = await bienImmoRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Bien Immobilier", request.Id.ToString());

        return await bienImmoRepository.DeleteAsync(bienImmo);
    }
}
