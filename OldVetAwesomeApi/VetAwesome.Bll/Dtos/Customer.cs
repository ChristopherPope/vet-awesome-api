namespace VetAwesome.Bll.Dtos
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string StreetAddress1 { get; set; } = null!;
        public string? StreetAddress2 { get; set; }
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public int StateId { get; set; }
        public string? CellPhone { get; set; }
        public string? HomePhone { get; set; }
        public string? WorkPhone { get; set; }
    }
}
