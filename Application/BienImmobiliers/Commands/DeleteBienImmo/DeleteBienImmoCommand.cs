using MediatR;

namespace Regies.Application.BienImmobiliers.Commands.DeleteBienImmo;

/// <summary>
/// Représente une commande pour supprimer un bien immobilier.
/// </summary>
public class DeleteBienImmoCommand(int _ID) : IRequest<bool>
{
    /// <summary>
    /// Obtient l'identifiant du bien immobilier à supprimer.
    /// </summary>
    public int Id { get; } = _ID;
}
