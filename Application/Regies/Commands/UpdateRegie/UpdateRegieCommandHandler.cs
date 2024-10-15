using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Regies.Application.Regies.DTOs;
using Regies.Domain.Exceptions;
using Regies.Domain.Model;
using Regies.Domain.Repositories;

namespace Regies.Application.Regies.Commands.UpdateRegie;

/// <summary>
/// Handles the UpdateRegieCommand.
/// </summary>
public class UpdateRegieCommandHandler(ILogger<UpdateRegieCommandHandler> logger, IRegieRepository regieRepository, IMapper mapper) : IRequestHandler<UpdateRegieCommand>
{

    /// <summary>
    /// Handles the UpdateRegieCommand.
    /// </summary>
    /// <param name="request">The UpdateRegieCommand object.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(UpdateRegieCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateRegieCommandHandler.Handle with Id {Id}", request.Id);
        var regie = await regieRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(typeof(Regie).ToString(), request.Id.ToString());
        
        regie = mapper.Map(request, regie);

        await regieRepository.UpdateAsync(regie);
    }
}
