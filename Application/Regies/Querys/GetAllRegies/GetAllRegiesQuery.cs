using MediatR;
using Regies.Application.Regies.DTOs;

namespace Regies.Application.Regies.Querys.GetAllRegies;

/// <summary>
/// Représente une requête pour obtenir toutes les régies.
/// </summary>
public class GetAllRegiesQuery : IRequest<IEnumerable<RegieDto>>
{
}
