using AutoMapper;
using VetAwesome.Application.Dtos;
using VetAwesome.Domain.Entities;
using VetAwesome.Domain.Enums;

namespace VetAwesome.Application.EntityDtoMapping;

internal sealed class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDto>()
            .ForMember(dto => dto.RoleId, opt => opt.MapFrom(entity => entity.UserRoleId))
            .ForMember(dto => dto.RoleName, opt => opt.MapFrom(entity => ((RoleTypes)entity.UserRoleId).ToString()));
    }
}
