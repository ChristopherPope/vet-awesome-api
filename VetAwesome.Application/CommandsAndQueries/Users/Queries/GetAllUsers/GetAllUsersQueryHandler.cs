using AutoMapper;
using MediatR;
using VetAwesome.Application.Dtos;
using VetAwesome.Application.Interfaces.Persistence;

namespace VetAwesome.Application.CommandsAndQueries.Users.Queries.GetAllUsers;

internal sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var userEntities = await unitOfWork.Users.ReadAllAsync(cancellationToken);

        return mapper.Map<IEnumerable<UserDto>>(userEntities);
    }
}
