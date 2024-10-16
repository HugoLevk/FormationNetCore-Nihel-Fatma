using MediatR;

namespace Regies.Application.BienImmobiliers.Commands.DeleteBienImmo;

public class DeleteBienImmoCommand(int _ID) : IRequest<bool>
{
    public int Id { get; } = _ID;
}
