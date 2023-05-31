namespace VetAwesome.Application.Dtos;

public sealed class CustomerDto
{
    public int Id { get; set; }
    public int StateId { get; set; }
    public string? Name { get; set; }
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? ZipCode { get; set; }
    public string? StateName { get; set; }
    public string? StateAbbreviation { get; set; }
    public string? Phone { get; set; }
}