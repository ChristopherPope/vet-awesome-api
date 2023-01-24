namespace VetAwesome.Bll.Dtos
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? CellPhone { get; set; }
        public int HouseholdId { get; set; }
    }
}
