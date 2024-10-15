using MediatR;

namespace Regies.Application.Regies.Commands.UpdateRegie;

/// <summary>
/// Commande Update Régie
/// </summary>
public class UpdateRegieCommand :IRequest
{
    /// <summary>
    /// Gets or sets the identifier of the regie.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the regie.
    /// </summary>
    public string Nom { get; set; } = default!;
     
    /// <summary>
    /// Gets or sets the description of the regie.
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// La régie est active
    /// </summary>
    public bool estActive { get; set; }
}
