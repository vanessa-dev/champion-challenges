namespace ChampionChallenges.Domain.Exceptions;

public class DomainException : Exception
{
    internal readonly List<string> _errors;

    public IReadOnlyCollection<string> Errors => _errors;
    
    public DomainException(string message, List<string> errors) : base(message)
    {
        _errors = errors;
    }
    
    public DomainException(string message) : base(message)
    {
        _errors = new List<string>();
    }

    public DomainException(string message, Exception inner) : base(message, inner)
    {
        _errors = new List<string>();
    } 
}