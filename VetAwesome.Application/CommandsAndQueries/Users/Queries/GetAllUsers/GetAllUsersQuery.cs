using MediatR;
using VetAwesome.Application.Dtos;

namespace VetAwesome.Application.CommandsAndQueries.Users.Queries.GetAllUsers;

public sealed record GetAllUsersQuery : IRequest<IEnumerable<UserDto>>;
