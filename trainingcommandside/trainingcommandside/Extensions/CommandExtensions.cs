using trainingcommandside.Commands.AcceptInvitation;
using trainingcommandside.Commands.CancelInvitation;
using trainingcommandside.Commands.RejectInvitation;
using trainingcommandside.Commands.SendInvitation;

namespace trainingcommandside.Extensions
{
    public static class CommandsExtensions
    {
        public static SendInvitationCommand ToCommand(this SendInvitaionRequest request)
        => new()
        {
            Id =   $"{request.MemberId}-{request.SubscriptionId}",
            UserId = request.UserId,
            MemberId = request.MemberId,
            AccountId = request.AccountId,
            SubscriptionId = request.SubscriptionId,
            Permissions = request.Permissions.ToList()

        };
        public static CancelInvitationCommand ToCommand(this CancelInvitaionRequest request)
      => new()
      {
          Id = $"{request.MemberId}-{request.SubscriptionId}",
          UserId = request.UserId,
          MemberId = request.MemberId,
          AccountId = request.AccountId,
          SubscriptionId = request.SubscriptionId,
          Permissions = request.Permissions.ToList()

      };
        public static AcceptInvitationCommand ToCommand(this AcceptInvitaionRequest request)
    => new()
    {
        Id = $"{request.MemberId}-{request.SubscriptionId}",
        UserId = request.UserId,
        MemberId = request.MemberId,
        AccountId = request.AccountId,
        SubscriptionId = request.SubscriptionId,

    };
        public static RejectInvitationCommand ToCommand(this RejectInvitaionRequest request)
    => new()
    {
        Id = $"{request.MemberId}-{request.SubscriptionId}",
        UserId = request.UserId,
        MemberId = request.MemberId,
        AccountId = request.AccountId,
        SubscriptionId = request.SubscriptionId,

    };
        


    }
    
}
