using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Application.Regies.DTOs;
using Regies.Domain.Repositories;

namespace Regies.Application.Regies.Querys.GetAllRegies;

/// <summary>
/// Handles the GetAllRegiesQuery and returns a list of RegieDto objects.
/// </summary>
/// <remarks>
/// Initializes a new instance of the GetAllRegiesQueryHandler class.
/// </remarks>
/// <param name="logger">The logger.</param>
/// <param name="mapper">The mapper.</param>
/// <param name="regieRepository">The regie repository.</param>
public class GetAllRegiesQueryHandler(ILogger<GetAllRegiesQueryHandler> logger, IMapper mapper, IRegieRepository regieRepository) : IRequestHandler<GetAllRegiesQuery, IEnumerable<RegieDto>>
{

    /// <summary>
    /// Handles the GetAllRegiesQuery and returns a list of RegieDto objects.
    /// </summary>
    /// <param name="request">The GetAllRegiesQuery.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of RegieDto objects.</returns>
    public async Task<IEnumerable<RegieDto>> Handle(GetAllRegiesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetAllRegiesQueryHandler.Handle");
        var regies = await regieRepository.GetAllAsync();
        var regiesDtos = mapper.Map<IEnumerable<RegieDto>>(regies);
        return regiesDtos;
    }
}
