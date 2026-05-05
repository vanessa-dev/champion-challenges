namespace ChampionChallenges.Application.DTOs.Invite;

public class InviteResponseDto(Guid id, Guid challengedId, Guid challengerId)
{
    public Guid Id { get; private set; } = id;
    public Guid ChallengedId { get; private set; } = challengedId;
    public Guid ChallengerId { get; private set; } = challengerId;
}