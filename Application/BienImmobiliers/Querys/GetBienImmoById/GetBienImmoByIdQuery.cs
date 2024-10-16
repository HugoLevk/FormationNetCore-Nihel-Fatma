using MediatR;
using Regies.Application.BienImmobiliers.DTOs;

namespace Regies.Application.BienImmobiliers.Querys.GetBienImmoById;

public class GetBienImmoByIdQuery(int id) : IRequest<BienImmobiliersDTOs>
{
    public int Id { get; } = id;
}
