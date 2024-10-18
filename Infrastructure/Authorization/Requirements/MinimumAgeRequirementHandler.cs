using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Regies.Application.User;
using Regies.Domain.Exceptions;

namespace Regies.Infrastructure.Authorization.Requirements;

public class MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirementHandler> logger,
                                            IUserContext userContext) : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override async Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var currentUser = await userContext.GetCurrentUser() ?? throw new NotFoundException("User","", true);

        logger.LogInformation("Checking if user {UserId} is at least {MinimumAge} years old.", currentUser.Id, requirement.MinimumAge);

        if (currentUser.BirthDate == null)
        {
            logger.LogWarning("User {UserId} does not have a birth date set.", currentUser.Id);
            context.Fail();
            return Task.CompletedTask;
        }

        if (currentUser.BirthDate.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.Now))
        {
            logger.LogInformation("Authorization suceeded.");
            context.Succeed(requirement);
        }
        else
        {
            logger.LogWarning("User {UserId} is not old enough.", currentUser.Id);
            context.Fail();
        }

        return Task.CompletedTask;
    }
}
