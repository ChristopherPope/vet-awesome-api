namespace VetAwesome.Bll.Dtos
{
    public class Appointment
    {
        public int Id { get; set; }
        public Pet Pet { get; set; } = new Pet();
        public User Veterinarian { get; set; } = new User();
        public DateTime StartTime { get; set; } = DateTime.MinValue;
        public DateTime EndTime { get; set; } = DateTime.MinValue;
    }
}
