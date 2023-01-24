namespace VetAwesome.Bll.Dtos
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VeterinarianId { get; set; }
        public DateTime StartTime { get; set; } = DateTime.MinValue;
        public DateTime EndTime { get; set; } = DateTime.MinValue;
    }
}
