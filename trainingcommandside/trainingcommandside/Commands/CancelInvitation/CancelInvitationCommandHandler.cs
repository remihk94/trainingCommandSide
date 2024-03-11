using MediatR;
using trainingcommandside.Abstraction;
using trainingcommandside.Commands.SendInvitation;
using trainingcommandside.Domain;
using trainingcommandside.Exceptions;

namespace trainingcommandside.Commands.CancelInvitation
{
    public class CancelInvitationCommandHandler(IEventStore eventStore) : IRequestHandler<CancelInvitationCommand, Guid>
    {
        private readonly IEventStore _eventStore = eventStore;
        public async Task<Guid> Handle(CancelInvitationCommand command, CancellationToken cancellationToken)
        {
            // await _queriesService.EnsurePhoneAndEmailAreUniqueAsync(command.Phone, command.Email, cancellationToken);

            var events = await _eventStore.GetAllAsync(command.Id, cancellationToken);

            if (events.Count == 0)
                throw new NotFoundException("Invitation not found");

            var invitation = Invitation.LoadFromHistory(events);

            invitation.CancelInvitation(command);


            await _eventStore.CommitAsync(invitation, cancellationToken);

            return new Guid(command.Id);


        }
    }
}
