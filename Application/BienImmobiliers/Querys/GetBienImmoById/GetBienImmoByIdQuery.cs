using MediatR;
using Regies.Application.BienImmobiliers.DTOs;

namespace Regies.Application.BienImmobiliers.Querys.GetBienImmoById;

/// <summary>
/// Représente une requête pour obtenir un bien immobilier par son identifiant.
/// </summary>
public class GetBienImmoByIdQuery(int id) : IRequest<BienImmobiliersDTOs>
{
    /// <summary>
    /// Obtient l'identifiant du bien immobilier.
    /// </summary>
    public int Id { get; } = id;
}
