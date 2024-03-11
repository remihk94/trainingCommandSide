using trainingcommandside.Commands.AcceptInvitation;
using trainingcommandside.Commands.CancelInvitation;
using trainingcommandside.Commands.RejectInvitation;
using trainingcommandside.Commands.SendInvitation;
using trainingcommandside.Events;

namespace trainingcommandside.Extensions
{
    public static class EventExtensions
    {
        public static InvitationSent ToEvent(this SendInvitationCommand command, int sequence) => new(
              AggregateId: command.Id,
              Sequence: sequence,
              DateTime: DateTime.UtcNow,
              Data: new InvitationSentData(
                  UserId: command.UserId,
                  MemberId: command.MemberId,
                  SubscriptionId: command.SubscriptionId,
                  AccountId: command.AccountId,
                  Permissions: command.Permissions
              ),
              UserId: command.UserId,
              Version: 1
          );
        public static InvitationCanceled ToEvent(this CancelInvitationCommand command, int sequence) => new(
            AggregateId: command.Id,
            Sequence: sequence,
            DateTime: DateTime.UtcNow,
            Data: new InvitationCanceledData(
                UserId: command.UserId,
                MemberId: command.MemberId,
                SubscriptionId: command.SubscriptionId,
                AccountId: command.AccountId,
                  Permissions: command.Permissions
            ),
            UserId: command.UserId,
            Version: 1
        );
        public static InvitationAccepted ToEventAccepted(this AcceptInvitationCommand command, int sequence) => new(
         AggregateId: command.Id,
         Sequence: sequence,
         DateTime: DateTime.UtcNow,
         Data: new InvitationAcceptedData(
             UserId: command.UserId,
             MemberId: command.MemberId,
             SubscriptionId: command.SubscriptionId,
             AccountId: command.AccountId
         ),
         UserId: command.UserId,
         Version: 1
         );
        public static MemberJoined ToEventJoined(this AcceptInvitationCommand command, int sequence) => new(
        AggregateId: command.Id,
        Sequence: sequence,
        DateTime: DateTime.UtcNow,
        Data: new MemberJoinedData(
         MemberId: command.MemberId,
         SubscriptionId: command.SubscriptionId
        ),
        UserId: command.UserId,
        Version: 1
        );
        public static InvitationRejected ToEvent(this RejectInvitationCommand command, int sequence) => new(
        AggregateId: command.Id,
        Sequence: sequence,
        DateTime: DateTime.UtcNow,
        Data: new InvitationRejectedData(
            UserId: command.UserId,
            MemberId: command.MemberId,
            SubscriptionId: command.SubscriptionId,
            AccountId: command.AccountId
        ),
        UserId: command.UserId,
        Version: 1
        );

      
    }
}
