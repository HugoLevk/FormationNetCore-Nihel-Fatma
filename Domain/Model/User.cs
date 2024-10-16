using Microsoft.AspNetCore.Identity;

namespace Regies.Domain.Model;

public class User : IdentityUser
{
    public DateOnly? BirthDate { get; set; }
    public string? Nationality { get; set; }
}
