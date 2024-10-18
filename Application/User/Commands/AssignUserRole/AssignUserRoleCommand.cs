using MediatR;

namespace Regies.Application.User.Commands.AssignUserRole;

/// <summary>
/// Represents a command to assign a role to a user.
/// </summary>
public class AssignUserRoleCommand : IRequest
{
    /// <summary>
    /// Gets or sets the user Email.
    /// </summary>
    public required string UserEmail { get; set; }

    /// <summary>
    /// Gets or sets the role.
    /// </summary>
    public required string Role { get; set; }
}
