using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Domain.Exceptions;
using Regies.Domain.Repositories;

namespace Regies.Application.BienImmobiliers.Commands.UpdateBienImmo;

public class UpdateBienImmoCommandHandler(ILogger<UpdateBienImmoCommandHandler> logger, IMapper mapper, IBienImmoRepository bienImmoRepository, IRegieRepository regieRepository) : IRequestHandler<UpdateBienImmoCommand>
{
    public async Task Handle(UpdateBienImmoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating real estate property with ID {@Id}.", request.Id);

        var bienImmo = await bienImmoRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Real estate property", request.Id.ToString());

        var regie = await regieRepository.GetByIdAsync(bienImmo.RegieId) ?? throw new NotFoundException("Régie", request.Id.ToString());

        mapper.Map(request, bienImmo);

        await bienImmoRepository.UpdateAsync(bienImmo);
  
    }
}
