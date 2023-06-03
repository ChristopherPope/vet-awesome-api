namespace VetAwesome.Application.Dtos;

public sealed class UserDto
{
    public string? Name { get; set; }
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string? RoleName { get; set; }
}
