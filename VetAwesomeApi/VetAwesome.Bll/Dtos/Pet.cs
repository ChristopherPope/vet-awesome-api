namespace VetAwesome.Bll.Dtos
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PetBreedId { get; set; }
        public int HouseholdId { get; set; }
    }
}
