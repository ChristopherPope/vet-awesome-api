using MediatR;
using VetAwesome.Domain.Entities;

namespace VetAwesome.Application.Customers.Users;

public sealed record ReadUsersCommand : IRequest<IEnumerable<User>>;
