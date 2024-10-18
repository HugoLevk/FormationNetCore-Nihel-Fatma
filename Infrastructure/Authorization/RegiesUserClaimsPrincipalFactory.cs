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
            id.AddClaim(new Claim(AppClaimTypes.s_Nationality, user.Nationality));
        }

        if (user.BirthDate != null)
        {
            id.AddClaim(new Claim(AppClaimTypes.s_BirthDate, user.BirthDate.Value.ToString("yyyy-MM-dd")));
        }
        return new ClaimsPrincipal(id);

    }
}
