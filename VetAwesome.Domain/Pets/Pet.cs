#nullable disable
using VetAwesome.Domain.Appointments;
using VetAwesome.Domain.Customers;
using VetAwesome.Domain.Interfaces;
using VetAwesome.Domain.PetBreeds;

namespace VetAwesome.Domain.Pets;

public partial class Pet : IEntity
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int PetBreedId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Customer Customer { get; set; }

    public virtual PetBreed PetBreed { get; set; }
}