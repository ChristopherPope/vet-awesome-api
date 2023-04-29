using MediatR;
using VetAwesome.Domain.Results;

namespace VetAwesome.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
