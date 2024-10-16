using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Regies.Application.User;

/// <summary>
/// Represents the user context for the application.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserContext"/> class.
/// </remarks>
public interface IUserContext
{
    /// <summary>
    /// Gets the current user.
    /// </summary>
    /// <returns>The current user.</returns>
    Task<CurrentUser?> GetCurrentUser();
}

/// <summary>
/// Represents the user context for the application.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserContext"/> class.
/// </remarks>
/// <param name="httpContextAccessor">The HTTP context accessor.</param>
public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    /// <summary>
    /// Gets the current user.
    /// </summary>
    /// <returns>The current user.</returns>
    public Task<CurrentUser?> GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User ?? throw new InvalidOperationException("No user found in the current context.");

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return Task.FromResult<CurrentUser?>(null);
        }

        var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(ClaimTypes.Email)!.Value;
        var roles = user.FindAll(ClaimTypes.Role).Select(c => c.Value);

        return Task.FromResult<CurrentUser?>(new CurrentUser(userId, email, roles));
    }
}
