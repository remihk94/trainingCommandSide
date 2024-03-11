using MediatR;
using trainingcommandside.Abstraction;
using trainingcommandside.Commands.CancelInvitation;
using trainingcommandside.Domain;
using trainingcommandside.Exceptions;

namespace trainingcommandside.Commands.RejectInvitation
{
    public class RejectInvitationCommandHandler(IEventStore eventStore) : IRequestHandler<RejectInvitationCommand, Guid>
    {
        private readonly IEventStore _eventStore = eventStore;
        public async Task<Guid> Handle(RejectInvitationCommand command, CancellationToken cancellationToken)
        {
            // await _queriesService.EnsurePhoneAndEmailAreUniqueAsync(command.Phone, command.Email, cancellationToken);

            var events = await _eventStore.GetAllAsync(command.Id, cancellationToken);

            if (events.Count == 0)
                throw new NotFoundException("Invitation not found");

            var invitation = Invitation.LoadFromHistory(events);

            invitation.RejectInvitation(command);


            await _eventStore.CommitAsync(invitation, cancellationToken);

            return new Guid(command.Id);
        }
    }
}
