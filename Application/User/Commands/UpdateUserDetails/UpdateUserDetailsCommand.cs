using MediatR;

namespace Regies.Application.User.Commands.UpdateUserDetails
{
    /// <summary>
    /// Represents a command to update user details.
    /// </summary>
    public class UpdateUserDetailsCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the birth date of the user.
        /// </summary>
        public required DateOnly BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the nationality of the user.
        /// </summary>
        public required string Nationality { get; set; }
    }
}
