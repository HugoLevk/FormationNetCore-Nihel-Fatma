namespace Regies.Domain.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a resource is not found.
/// </summary>
public class NotFoundException(string resourceName, string resourceIdentifier, bool userContext = false) : Exception( userContext ? $"No {resourceName} found in the current context." : $"The {resourceName} with identifier {resourceIdentifier} was not found.")
{
}
