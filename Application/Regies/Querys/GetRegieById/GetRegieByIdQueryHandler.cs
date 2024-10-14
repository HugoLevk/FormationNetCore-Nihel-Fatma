using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Application.Regies.DTOs;
using Regies.Domain.Repositories;

namespace Regies.Application.Regies.Querys.GetRegieById;

/// <summary>
/// Handles the GetRegieByIdQuery and returns the corresponding RegieDto.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetRegieByIdQueryHandler"/> class.
/// </remarks>
/// <param name="logger">The p_Logger.</param>
/// <param name="mapper">The p_Mapper.</param>
/// <param name="regieRepository">The regie repository.</param>
public class GetRegieByIdQueryHandler(ILogger<GetRegieByIdQueryHandler> logger,
                                IMapper mapper,
                                IRegieRepository regieRepository) : IRequestHandler<GetRegieByIdQuery, RegieDto>
{

    /// <summary>
    /// Handles the GetRegieByIdQuery and returns the corresponding RegieDto.
    /// </summary>
    /// <param name="request">The GetRegieByIdQuery.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The corresponding RegieDto.</returns>
    public async Task<RegieDto> Handle(GetRegieByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetRegieByIdQueryHandler.Handle with Id {Id}", request.Id);
        var regie = await regieRepository.GetByIdAsync(request.Id);
        var regieDto = mapper.Map<RegieDto>(regie);
        return regieDto;
    }
}
