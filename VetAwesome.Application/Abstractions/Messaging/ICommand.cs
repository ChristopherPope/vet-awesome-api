using MediatR;
using VetAwesome.Domain.Results;

namespace VetAwesome.Application.Abstractions.Messaging;

public interface ICommand : MediatR.IRequest<Result>
{
}

public interface IRequest<TResponse> : MediatR.IRequest<Result<TResponse>>
{
}
