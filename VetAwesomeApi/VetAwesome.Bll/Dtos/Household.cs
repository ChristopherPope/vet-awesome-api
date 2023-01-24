namespace VetAwesome.Bll.Dtos
{
    public class Household
    {
        public int Id { get; set; }
        public string StreetAddress1 { get; set; } = string.Empty;
        public string? StreetAddress2 { get; set; }
        public int StateId { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
