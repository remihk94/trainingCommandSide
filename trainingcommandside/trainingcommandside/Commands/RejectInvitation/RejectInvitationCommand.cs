using MediatR;

namespace trainingcommandside.Commands.RejectInvitation
{
    public class RejectInvitationCommand : IRequest<Guid>
    {
        public required string Id { get; init; }
        public required string MemberId { get; init; }
        public required string SubscriptionId { get; init; }

        public required string UserId { get; init; }

        public required string AccountId { get; init; }
    }
}
