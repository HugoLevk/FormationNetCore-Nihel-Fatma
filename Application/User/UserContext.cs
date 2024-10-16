using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Regies.Application.User;

public interface IUserContext
{
    /// <summary>
    /// Gets the current user.
    /// </summary>
    /// <returns>The current user.</returns>
    Task<CurrentUser> GetCurrentUser();
}

/// <summary>
/// Represents the user context for the application.
/// </summary>
public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserContext"/> class.
    /// </summary>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Gets the current user.
    /// </summary>
    /// <returns>The current user.</returns>
    public async Task<CurrentUser> GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext.User ?? throw new InvalidOperationException("No user found in the current context.");

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(ClaimTypes.Email)!.Value;
        var roles = user.FindAll(ClaimTypes.Role).Select(c => c.Value);

        return new CurrentUser(userId, email, roles);
    }
}
