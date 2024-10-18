using FluentValidation;
using Regies.Domain.Constants;

namespace Regies.Application.User.Commands.AssignUserRole;

public class AsssignUserRoleCommandValidator : AbstractValidator<AssignUserRoleCommand>
{

    private static readonly List<string> s_RoleNames = [UserRoles.s_User.Name, UserRoles.s_Admin.Name, UserRoles.s_Manager.Name];


    public AsssignUserRoleCommandValidator()
    {
        RuleFor(x => x.UserEmail).NotEmpty().EmailAddress();
        RuleFor(x => x.Role).NotEmpty().Must(x => s_RoleNames.Contains(x));
    }
}
