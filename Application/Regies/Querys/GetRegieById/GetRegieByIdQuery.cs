using MediatR;
using Regies.Application.Regies.DTOs;

namespace Regies.Application.Regies.Querys.GetRegieById;

public class GetRegieByIdQuery(int id) : IRequest<RegieDto>
{
    public int Id { get; } = id; //Equivalent à public int Id { get; init; }

}
