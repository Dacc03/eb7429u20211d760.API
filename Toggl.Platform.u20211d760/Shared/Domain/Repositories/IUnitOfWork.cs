namespace Toggl.Platform.u20211d760.Shared.Domain.Repositories;

/// <summary>
/// Represents the unit of work pattern for managing database transactions.
/// </summary>
/// <remarks>
/// Author: Antonio Rodrigo Duran Diaz
/// </remarks>
public interface IUnitOfWork
{
    /// <summary>
    /// Asynchronously completes all pending changes in the current transaction.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing the number of affected records.</returns>
    Task<int> CompleteAsync();
}
