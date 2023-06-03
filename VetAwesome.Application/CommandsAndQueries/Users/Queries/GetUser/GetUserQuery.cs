using MediatR;
using VetAwesome.Application.Dtos;

namespace VetAwesome.Application.CommandsAndQueries.Users.Queries.GetUser;

internal record GetUserQuery(int UserId) : IRequest<UserDto?>;
