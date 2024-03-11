using MediatR;
using trainingcommandside.Abstraction;
using trainingcommandside.Domain;
using trainingcommandside.Exceptions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace trainingcommandside.Commands.SendInvitation
{
    public class SendInvitationCommandHandler(IEventStore eventStore) : IRequestHandler<SendInvitationCommand, Guid>
    {
        private readonly IEventStore _eventStore = eventStore;
        public async Task<Guid> Handle(SendInvitationCommand command, CancellationToken cancellationToken)
        {

            var events = await _eventStore.GetAllAsync(command.Id, cancellationToken);

            if (events.Count == 0)
                throw new NotFoundException("Invitation not found");

            var invitation = Invitation.LoadFromHistory(events);

             invitation.SendInvitation(command);


            await _eventStore.CommitAsync(invitation, cancellationToken);

            return new Guid(command.Id);


        }
    }
}
