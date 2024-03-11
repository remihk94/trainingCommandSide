using MediatR;
using trainingcommandside.Abstraction;
using trainingcommandside.Commands.CancelInvitation;
using trainingcommandside.Domain;
using trainingcommandside.Exceptions;

namespace trainingcommandside.Commands.AcceptInvitation
{
    public class AcceptInvitationCommandHandler(IEventStore eventStore) : IRequestHandler<AcceptInvitationCommand, Guid>
    {
        private readonly IEventStore _eventStore = eventStore;
        public async Task<Guid> Handle(AcceptInvitationCommand command, CancellationToken cancellationToken)
        {

            var events = await _eventStore.GetAllAsync(command.Id, cancellationToken);

            if (events.Count == 0)
                throw new NotFoundException("Invitation not found");
     

            var invitation = Invitation.LoadFromHistory(events);

            invitation.AcceptInvitation(command);


            await _eventStore.CommitAsync(invitation, cancellationToken);

            return new Guid(command.Id);


        }
    }
}
