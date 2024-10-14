using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Application.Regies.DTOs;
using Regies.Domain.Model;
using Regies.Domain.Repositories;

namespace Regies.Application.Regies.Commands.CreateRegie;

public class CreateRegieCommandHandler(IMapper mapper, ILogger<CreateRegieCommandHandler> logger, IRegieRepository regieRepository) : IRequestHandler<CreateRegieCommand, int>
{
    public async Task<int> Handle(CreateRegieCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating Régie with name {@Regie}.", request.Nom);
        var regie = mapper.Map<Regie>(request);
        var regieId = await regieRepository.CreateAsync(regie);
        return regieId;
    }
}
