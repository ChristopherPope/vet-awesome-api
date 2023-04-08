namespace VetAwesome.Bll.Dtos
{
    public class PetBreed
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PetTypeId { get; set; }
    }
}
