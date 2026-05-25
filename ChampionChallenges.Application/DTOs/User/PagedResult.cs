namespace ChampionChallenges.Application.DTOs.User;

public sealed class PagedResult<T>
{
    public required IReadOnlyCollection<T> Items { get; init; }

    public required int TotalItems { get; init; }

    public required int Page { get; init; }

    public required int PageSize { get; init; }

    public int TotalPages => PageSize <= 0
        ? 0
        : (int)Math.Ceiling(TotalItems / (double)PageSize);
}
