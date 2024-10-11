using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Application.Regies.DTOs;
using Regies.Domain.Repositories;

namespace Regies.Application.Regies.Querys.GetAllRegies;

public class GetAllRegiesQueryHandler(ILogger<GetAllRegiesQueryHandler> logger, IMapper mapper, IRegieRepository regieRepository) : IRequestHandler<GetAllRegiesQuery, IEnumerable<RegieDto>>
{
    public async Task<IEnumerable<RegieDto>> Handle(GetAllRegiesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetAllRegiesQueryHandler.Handle");
        var regies = await regieRepository.GetAllAsync();
        var regiesDtos = mapper.Map<IEnumerable<RegieDto>>(regies);
        return regiesDtos;
    }
}
