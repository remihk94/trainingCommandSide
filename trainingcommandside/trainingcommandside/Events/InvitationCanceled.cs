namespace trainingcommandside.Events
{
    public record InvitationCanceled(
       string AggregateId,
       int Sequence,
       DateTime DateTime,
       InvitationCanceledData Data,
       string UserId,
       int Version
   ) : Event<InvitationCanceledData>(AggregateId, Sequence, DateTime, Data, UserId, Version);

    public record InvitationCanceledData(
        string UserId,
        string MemberId,
        string SubscriptionId,
        string AccountId,
        List<string> Permissions
    );
}
