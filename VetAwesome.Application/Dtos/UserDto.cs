using VetAwesome.Domain.Enums;

namespace VetAwesome.Application.Dtos;

public sealed class UserDto
{
    public string? Name { get; set; }
    public int Id { get; set; }
    public string? RoleName { get; set; }
    public RoleTypes Role { get; set; }
}
