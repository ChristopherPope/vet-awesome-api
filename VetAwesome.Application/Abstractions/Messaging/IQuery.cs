using MediatR;
using VetAwesome.Domain.Results;

namespace VetAwesome.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}