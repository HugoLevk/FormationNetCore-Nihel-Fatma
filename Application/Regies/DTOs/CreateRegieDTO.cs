using System.ComponentModel.DataAnnotations;

namespace Regies.Application.Regies.DTOs;

public class CreateRegieDTO
{
    [StringLength(100, MinimumLength = 3)]
    public string Nom { get; set; } = default!;
    [Required]
    public string Description { get; set; } = default!;
    public bool estActive { get; set; }
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? contactEmail { get; set; }
    [Phone(ErrorMessage = "Invalid Phone Number")]
    public string? contactTelephone { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? StreetNumber { get; set; }
    [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Insert a valid ZipCode (XX-XXX).")]
    public string? ZipCode { get; set; }
}
