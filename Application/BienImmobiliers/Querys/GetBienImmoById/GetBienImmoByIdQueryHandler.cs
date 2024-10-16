using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Application.BienImmobiliers.DTOs;
using Regies.Domain.Exceptions;
using Regies.Domain.Repositories;

namespace Regies.Application.BienImmobiliers.Querys.GetBienImmoById;

public class GetBienImmoByIdQueryHandler(ILogger<GetBienImmoByIdQueryHandler> logger,IMapper mapper, IBienImmoRepository bienImmoRepository) : IRequestHandler<GetBienImmoByIdQuery, BienImmobiliersDTOs>
{
    public async Task<BienImmobiliersDTOs> Handle(GetBienImmoByIdQuery request, CancellationToken cancellationToken)
    {
        var bienImmo = await bienImmoRepository.GetByIdAsync(request.Id)?? throw new NotFoundException("Bien Immobilier", request.Id.ToString());

        var bienImmoDTO = mapper.Map<BienImmobiliersDTOs>(bienImmo);

        return bienImmoDTO;
    }
}
