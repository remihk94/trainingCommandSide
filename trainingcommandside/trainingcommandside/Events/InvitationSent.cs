namespace trainingcommandside.Events
{
    public record InvitationSent(
        string AggregateId,
        int Sequence,
        DateTime DateTime,
        InvitationSentData Data,
        string UserId,
        int Version
    ) : Event<InvitationSentData>(AggregateId, Sequence, DateTime, Data, UserId, Version);

    public record InvitationSentData(
        string UserId,
        string MemberId,
        string SubscriptionId,
        string AccountId,
        List<string> Permissions
    );
}
