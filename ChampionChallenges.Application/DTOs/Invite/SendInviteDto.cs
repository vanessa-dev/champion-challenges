namespace ChampionChallenges.Application.DTOs.Invite;

public class SendInviteDto(Guid challengedId, Guid  challengerId) 
{
    public Guid ChallengedId { get; private set; } = challengedId;
    public Guid ChallengerId { get; private set; } =  challengerId;
 
}