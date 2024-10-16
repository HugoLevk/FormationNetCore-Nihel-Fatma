using MediatR;

namespace Regies.Application.BienImmobiliers.Commands.UpdateBienImmo;

public class UpdateBienImmoCommand : IRequest
{
    public int Id { get; set; }
    public string Description { get; set; } 
    public string Rue { get; set; }
    public string Ville { get; set; }
    public string CodePostal { get; set; }
    public string NumeroRue { get; set; }
}
