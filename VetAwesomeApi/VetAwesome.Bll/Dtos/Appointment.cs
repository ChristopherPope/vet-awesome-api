namespace VetAwesome.Bll.Dtos
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; } = DateTime.MinValue;
        public DateTime EndTime { get; set; } = DateTime.MinValue;
        public string PetName { get; set; } = string.Empty;
        public string PetType { get; set; } = string.Empty;
        public string PetBreed { get; set; } = string.Empty;
        public string Veterinarian { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string StreetAddress1 { get; set; } = string.Empty;
        public string StreetAddress2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string StateName { get; set; } = string.Empty;
        public string StateAbbreviation { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string CellPhone { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string WorkPhone { get; set; } = string.Empty;
        public int StateId { get; set; }
        public int CustomerId { get; set; }
        public int PetId { get; set; }
        public int PetBreedId { get; set; }
        public int PetTypeId { get; set; }
        public int VeterinarianId { get; set; }
    }
}
