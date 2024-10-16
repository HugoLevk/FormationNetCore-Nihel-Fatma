using MediatR;
using Regies.Application.BienImmobiliers.DTOs;

namespace Regies.Application.BienImmobiliers.Querys.GetAllBienImmo;

/// <summary>
/// Récupères TOUS les biens immobiliers de la BDD
/// </summary>
public class GetAllBienImmoQuery : IRequest<IEnumerable<BienImmobiliersDTOs>>
{
}
