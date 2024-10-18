namespace Regies.Application.User;

/// <summary>
/// Represents the current user.
/// </summary>
public record CurrentUser(string Id, string Email, IEnumerable<string> Roles, string? Nationality, DateOnly? BirthDate)
{
    /// <summary>
    /// Checks if the user is enrolled in the specified role.
    /// </summary>
    /// <param name="role">The role to check.</param>
    /// <returns><c>true</c> if the user is enrolled in the role; otherwise, <c>false</c>.</returns>
    public bool IsEnroledIn(string role) => Roles.Contains(role);

    /// <summary>
    /// Gets a value indicating whether the user is an admin.
    /// </summary>
    public bool IsAdmin => IsEnroledIn("Admin");

    /// <summary>
    /// Returns a string that represents the current user.
    /// </summary>
    /// <returns>A string that represents the current user.</returns>
    public override string ToString()
    {
        return $"Id: {Id}, Email: {Email}, Roles: {string.Join(", ", Roles)}, BirthDate : {BirthDate}, Naionality : {Nationality} ";
    }
}
