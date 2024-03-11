using Microsoft.Extensions.Logging;
using trainingcommandside.Domain;
using trainingcommandside.Events;

namespace trainingcommandside.Abstraction
{
    public interface IEventStore
    {
        Task<List<Event>> GetAllAsync(string aggregateId, CancellationToken cancellationToken);
        Task CommitAsync(Invitation invitation, CancellationToken cancellationToken);
    }
}
