namespace GymTestAPI.Models
{
    public class TimeSlot
    {
        public int TimeSlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string PartOfDay { get; set; }

        // Navigation Properties
        public ICollection<Reservation> Reservations { get; set; }
    }

}
