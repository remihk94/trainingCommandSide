using MediatR;

namespace trainingcommandside.Commands.SendInvitation
{
    public class SendInvitationCommand : IRequest<Guid> 
    {
        public SendInvitationCommand()
        {
            Permissions = [];
        }
        public required string Id { get; init; }
        public required string MemberId { get; init; }
        public required string SubscriptionId { get; init; }
        public required string UserId { get; init; }
        public required string AccountId { get; init; }
        public required List<string> Permissions { get; set; }

    }
}
