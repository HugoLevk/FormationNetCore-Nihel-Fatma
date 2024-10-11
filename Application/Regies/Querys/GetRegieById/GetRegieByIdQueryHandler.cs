using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Application.Regies.DTOs;
using Regies.Domain.Repositories;

namespace Regies.Application.Regies.Querys.GetRegieById;

public class GetRegieByIdQueryHandler(ILogger<GetRegieByIdQueryHandler> logger,
                                        IMapper mapper,
                                        IRegieRepository regieRepository) : IRequestHandler<GetRegieByIdQuery, RegieDto>
{
    public async Task<RegieDto> Handle(GetRegieByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetRegieByIdQueryHandler.Handle with Id {Id}", request.Id);
        var regie = await regieRepository.GetByIdAsync(request.Id);
        var regieDto = mapper.Map<RegieDto>(regie);
        return regieDto;
    }
}
