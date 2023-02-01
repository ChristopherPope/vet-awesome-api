namespace VetAwesome.Bll.Dtos
{
    public class Household
    {
        public int Id { get; set; }
        public string StreetAddress1 { get; set; } = string.Empty;
        public string? StreetAddress2 { get; set; }
        public State State { get; set; } = new State();
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
