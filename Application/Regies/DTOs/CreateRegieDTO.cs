using System.ComponentModel.DataAnnotations;

namespace Regies.Application.Regies.DTOs;

public class CreateRegieDTO
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
