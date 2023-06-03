using AutoMapper;
using MediatR;
using VetAwesome.Application.Dtos;
using VetAwesome.Application.Interfaces.Persistence;

namespace VetAwesome.Application.CommandsAndQueries.Users.Queries.GetUser;

internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto?>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<UserDto?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.ReadUserAsync(request.UserId, cancellationToken);

        return mapper.Map<UserDto>(user);
    }
}
