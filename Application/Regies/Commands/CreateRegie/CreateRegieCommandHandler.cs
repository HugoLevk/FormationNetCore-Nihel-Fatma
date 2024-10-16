using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Application.Regies.DTOs;
using Regies.Application.User;
using Regies.Domain.Model;
using Regies.Domain.Repositories;

namespace Regies.Application.Regies.Commands.CreateRegie;

/// <summary>
/// Handles the command to create a new Régie.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CreateRegieCommandHandler"/> class.
/// </remarks>
/// <param name="mapper">The mapper.</param>
/// <param name="logger">The logger.</param>
/// <param name="regieRepository">The regie repository.</param>
public class CreateRegieCommandHandler(IMapper mapper, ILogger<CreateRegieCommandHandler> logger, IRegieRepository regieRepository) : IRequestHandler<CreateRegieCommand, int>
{
    /// <summary>
    /// Handles the create regie command.
    /// </summary>
    /// <param name="request">The create regie command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The ID of the created regie.</returns>
    public async Task<int> Handle(CreateRegieCommand request, CancellationToken cancellationToken)
    { 
        logger.LogInformation("Creating Régie with name {@Regie}.", request.Nom);
        var regie = mapper.Map<Regie>(request);
        var regieId = await regieRepository.CreateAsync(regie);
        return regieId;
    }
}
