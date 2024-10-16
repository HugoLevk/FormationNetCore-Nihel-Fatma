using MediatR;

namespace Regies.Application.User.Commands.UpdateUserDetails
{
    public class UpdateUserDetailsCommand : IRequest<bool>
    { 
        public required DateOnly BirthDate { get; set; }
        public required string Nationality { get; set; }
    }
}
