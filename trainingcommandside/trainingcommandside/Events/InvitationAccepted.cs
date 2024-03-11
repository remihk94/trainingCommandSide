namespace trainingcommandside.Events
{
    public record InvitationAccepted(
       string AggregateId,
       int Sequence,
       DateTime DateTime,
       InvitationAcceptedData Data,
       string UserId,
       int Version
   ) : Event<InvitationAcceptedData>(AggregateId, Sequence, DateTime, Data, UserId, Version);

    public record InvitationAcceptedData(
        string UserId,
        string MemberId,
        string SubscriptionId,
        string AccountId
    );
}
