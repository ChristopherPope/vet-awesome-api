using MediatR;
using VetAwesome.Domain.Results;

namespace VetAwesome.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : MediatR.IRequest<Result<TResponse>>
{
}