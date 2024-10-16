using Microsoft.AspNetCore.Identity;

namespace Regies.Domain.Model;

public class User : IdentityUser
{
    public DateOnly BirthDate { get; set; } = new DateOnly(2000, 01, 01);
    public string Nationality { get; set; } = "German";
}
