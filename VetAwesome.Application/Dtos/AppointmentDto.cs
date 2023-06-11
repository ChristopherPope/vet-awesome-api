namespace VetAwesome.Application.Dtos;

public sealed class AppointmentDto
{
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAllDay { get; set; }
    public bool IsBlock { get; set; }
    public bool IsReadonly { get; set; }
    public int ResourceId { get; set; } = 1;
    public int RoomId { get; set; } = 1;
    public int CalendarId { get; set; } = 1;
}
