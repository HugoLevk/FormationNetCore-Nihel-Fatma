namespace Regies.Domain.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a resource is not found.
/// </summary>
public class NotFoundException(string resourceName, string resourceIdentifier) : Exception($"The {resourceName} with identifier {resourceIdentifier} was not found.")
{
}
