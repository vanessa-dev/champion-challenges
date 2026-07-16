using ChampionChallenges.Domain.Enums;

namespace ChampionChallenges.Application.DTOs.Challenge;

public class InviteSummaryDto(Guid id, Guid challengedId, string challengedName, InviteStatus status, DateTime invitedAt, DateTime? respondedAt)
{
    public Guid Id { get; private set; } = id;
    public Guid ChallengedId { get; private set; } = challengedId;
    public string ChallengedName { get; private set; } = challengedName;
    public InviteStatus Status { get; private set; } = status;
    public DateTime InvitedAt { get; private set; } = invitedAt;
    public DateTime? RespondedAt { get; private set; } = respondedAt;
}
