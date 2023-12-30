namespace VetAwesome.Application.Interfaces;
public interface IResponse
{
    bool IsFailure { get; }
    bool IsSuccess { get; }
    string FailureMessage { get; }
}
