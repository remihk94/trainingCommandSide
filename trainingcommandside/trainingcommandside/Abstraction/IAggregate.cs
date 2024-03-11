using Microsoft.Extensions.Logging;
using trainingcommandside.Events;

namespace trainingcommandside.Abstraction
{
    public interface IAggregate
    {
        string Id { get; }
        int Sequence { get; }
        IReadOnlyList<Event> GetUncommittedEvents();
        void MarkChangesAsCommitted();
    }
}
