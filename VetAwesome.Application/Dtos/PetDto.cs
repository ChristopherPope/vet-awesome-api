namespace VetAwesome.Application.Dtos;

public sealed class PetDto
{
    public PetBreedDto? PetBreeds { get; set; }
    public CustomerDto? Owner { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
}
