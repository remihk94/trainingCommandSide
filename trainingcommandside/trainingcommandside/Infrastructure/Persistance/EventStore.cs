using Microsoft.EntityFrameworkCore;
using trainingcommandside.Abstraction;
using trainingcommandside.Domain;
using trainingcommandside.Events;
using trainingcommandside.Infrastructure.MessageBus;

namespace trainingcommandside.Infrastructure.Persistance
{
    public class EventStore(ApplicationDbContext context, ServiceBusPublisher publisher) : IEventStore
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ServiceBusPublisher _publisher = publisher;

        public Task<List<Event>> GetAllAsync(string aggregateId, CancellationToken cancellationToken) =>
            _context.Events
                .Where(x => x.AggregateId == aggregateId)
                .OrderBy(x => x.Id)
                .ToListAsync(cancellationToken);

        public async Task CommitAsync(Invitation invitation, CancellationToken cancellationToken)
        {
            var events = invitation.GetUncommittedEvents();
            var messages = events.Select(x => new OutboxMessage(x));

            await _context.Events.AddRangeAsync(events, cancellationToken);
            await _context.OutboxMessages.AddRangeAsync(messages, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            _publisher.StartPublishing();
        }

        
    }
}
