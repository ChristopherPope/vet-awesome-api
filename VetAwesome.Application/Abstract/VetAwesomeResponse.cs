namespace VetAwesome.Application.Abstract;
public abstract class VetAwesomeResponse
{
    public bool IsFailure { get; protected set; }
    public bool IsSuccess => !IsFailure;
    public string FailureMessage { get; protected set; } = string.Empty;
}
