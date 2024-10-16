using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Regies.Domain.Exceptions;
using Regies.Domain.Model;

namespace Regies.Application.User.Commands.UpdateUserDetails;

public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> logger,
    IUserContext userContext,
    IUserStore<Domain.Model.User> userStore) : IRequestHandler<UpdateUserDetailsCommand, bool>
{
    public async Task<bool> Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating user details for user {UserId}.", userContext.GetCurrentUser().Id);
        CurrentUser user = await userContext.GetCurrentUser() ?? throw new NotFoundException("User", "", true) ;

        Domain.Model.User dbUser = await userStore.FindByIdAsync(user.Id.ToString(), cancellationToken) ?? throw new NotFoundException("User",user.Id.ToString());

        dbUser.Nationality = request.Nationality;
        dbUser.BirthDate = request.BirthDate;

        await userStore.UpdateAsync(dbUser, cancellationToken);

        return true;
    }
}
