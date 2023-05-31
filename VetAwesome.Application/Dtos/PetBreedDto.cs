namespace VetAwesome.Application.Dtos;

public sealed class PetBreedDto
{
    public string? PetTypeName { get; set; }
    public string? Name { get; set; }
    public int Id { get; set; }
    public int PetTypeId { get; set; }
}
