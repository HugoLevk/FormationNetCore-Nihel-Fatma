using MediatR;

namespace Regies.Application.Regies.Commands.CreateRegie;

public class CreateRegieCommand : IRequest<int>
{
    public string Nom { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool estActive { get; set; }
    public string? contactEmail { get; set; }
    public string? contactTelephone { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? StreetNumber { get; set; }
    public string? ZipCode { get; set; }
}
