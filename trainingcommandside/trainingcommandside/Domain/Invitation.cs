using Microsoft.AspNetCore.Http.HttpResults;
using System.Numerics;
using trainingcommandside.Abstraction;
using trainingcommandside.Commands.AcceptInvitation;
using trainingcommandside.Commands.CancelInvitation;
using trainingcommandside.Commands.RejectInvitation;
using trainingcommandside.Commands.SendInvitation;
using trainingcommandside.Events;
using trainingcommandside.Exceptions;
using trainingcommandside.Extensions;

namespace trainingcommandside.Domain
{
    public class Invitation : Aggregate<Invitation>, IAggregate
    {
        public Invitation()
        {
            Permissions = [];
        }
        public string AccountId { get; private set; } = string.Empty;
        public string SubscriptionId { get; private set; } = string.Empty;
        public string MemberId { get; private set; } = string.Empty;
        public string UserId { get; private set; } = string.Empty;
        public string Status { get; private set; } = string.Empty;
        public List<string> Permissions { get;   set; }



        protected override void Mutate(Event @event)
        {
            switch (@event)
            {
                case InvitationSent e:
                    Mutate(e);
                    break;
                case InvitationCanceled e:
                    Mutate(e);
                    break;
                case InvitationAccepted e:
                    Mutate(e);
                    break;
                case InvitationRejected e:
                    Mutate(e);
                    break;
            }
        }

        public void Mutate(InvitationSent @event)
        {

            SubscriptionId = @event.Data.SubscriptionId;
            UserId = @event.Data.UserId;
            MemberId = @event.Data.MemberId;
            AccountId = @event.Data.AccountId;
            Permissions = @event.Data.Permissions;
            Status = "Pending";
        }

        public void Mutate(InvitationCanceled @event)
        {
            SubscriptionId = @event.Data.SubscriptionId;
            UserId = @event.Data.UserId;
            MemberId = @event.Data.MemberId;
            AccountId = @event.Data.AccountId;
            Permissions = @event.Data.Permissions;
            Status = "Canceled";
        }
        public void Mutate(InvitationAccepted @event)
        {
            SubscriptionId = @event.Data.SubscriptionId;
            UserId = @event.Data.UserId;
            MemberId = @event.Data.MemberId;
            AccountId = @event.Data.AccountId;
            Status = "Accepted";
        }
        public void Mutate(InvitationRejected @event)
        {
            SubscriptionId = @event.Data.SubscriptionId;
            UserId = @event.Data.UserId;
            MemberId = @event.Data.MemberId;
            AccountId = @event.Data.AccountId;
            Status = "Rejected";
        }
        public void SendInvitation(SendInvitationCommand command)
        {
            var userId = command.UserId;
           // user id shoul not be null , he should be an owner

            if(userId == string.Empty)
                throw new NotFoundException("Owner not found");
            ApplyNewChange(command.ToEvent(NextSequence));
        }
        public void CancelInvitation(CancelInvitationCommand command)
        {
            var userId = command.UserId;

            // user id shoul not be null , he should be an owner
            if (userId == string.Empty)
                throw new NotFoundException("Owner not found");

            ApplyNewChange(command.ToEvent(NextSequence));
        }
        public void AcceptInvitation(AcceptInvitationCommand command)
        {
            // the person who accept should be member
            var memberId = command.MemberId;

            if (memberId == string.Empty)
                throw new NotFoundException("Member not found");

            ApplyNewChange(command.ToEventAccepted(NextSequence));
            ApplyNewChange(command.ToEventJoined(NextSequence + 1));

        }
        public void RejectInvitation(RejectInvitationCommand command)
        {
            // the person who reject is member
            var memberId = command.MemberId;
           
            if (memberId == string.Empty)
                throw new NotFoundException("Member not found");
         
            ApplyNewChange(command.ToEvent(NextSequence));
        }
    }
}
