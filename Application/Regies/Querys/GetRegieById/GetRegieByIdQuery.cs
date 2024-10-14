using MediatR;
using Regies.Application.Regies.DTOs;

namespace Regies.Application.Regies.Querys.GetRegieById;

/// <summary>
/// Représente une requête pour obtenir une régie par son identifiant.
/// </summary>
public class GetRegieByIdQuery(int id) : IRequest<RegieDto>
{
    /// <summary>
    /// Obtient ou définit l'identifiant de la régie.
    /// </summary>
    /// Equivalent à public int Id { get; init; }
    public int Id { get; } = id; 
}
