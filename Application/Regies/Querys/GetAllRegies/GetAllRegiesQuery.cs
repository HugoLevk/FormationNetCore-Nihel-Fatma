using MediatR;
using Regies.Application.Regies.DTOs;

namespace Regies.Application.Regies.Querys.GetAllRegies;

public class GetAllRegiesQuery : IRequest<IEnumerable<RegieDto>>
{
}
