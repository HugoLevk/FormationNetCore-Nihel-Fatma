using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Regies.Domain.Model;
using Regies.Infrastructure.Constants;
using System.Security.Claims;

namespace Regies.Infrastructure.Authorization;

public class RegiesUserClaimsPrincipalFactory(UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    IOptions<IdentityOptions> optionsAccessor) : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, optionsAccessor)
{
    public override async Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var id = await GenerateClaimsAsync(user);

        if (user.Nationality != null)
        {
            id.AddClaim(new Claim(AppClaimTypes.Nationality, user.Nationality));
        }

        if (user.BirthDate != null)
        {
            id.AddClaim(new Claim(AppClaimTypes.BirthDate, user.BirthDate.Value.ToString("dd-MM-yyyy")));
        }
        return new ClaimsPrincipal(id);

    }
}
