﻿using MediatR;

namespace Regies.Application.User.Commands.UnassignUserRole;

public class UnassignUserRoleCommand : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string Role { get; set; } = default!;
}
