using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Regies.Domain.Exceptions;
using Regies.Domain.Model;

namespace Regies.Application.User.Commands.UpdateUserDetails;

/// <summary>
/// Handles the command to update user details.
/// </summary>
/// <param name="logger">The logger.</param>
/// <param name="userContext">The user context.</param>
/// <param name="userStore">The user store.</param>
public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> logger,
    IUserContext userContext,
    IUserStore<Domain.Model.User> userStore) : IRequestHandler<UpdateUserDetailsCommand, bool>
{
    /// <summary>
    /// Handles the update user details command.
    /// </summary>
    /// <param name="request">The update user details command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A boolean indicating whether the update was successful or not.</returns>
    public async Task<bool> Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating user details for user {UserId}.", userContext.GetCurrentUser().Id);
        CurrentUser user = await userContext.GetCurrentUser() ?? throw new NotFoundException("User", "", true);

        Domain.Model.User dbUser = await userStore.FindByIdAsync(user.Id.ToString(), cancellationToken) ?? throw new NotFoundException("User", user.Id.ToString());

        dbUser.Nationality = request.Nationality;
        dbUser.BirthDate = request.BirthDate;

        await userStore.UpdateAsync(dbUser, cancellationToken);

        return true;
    }
}
