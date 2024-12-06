using System.ComponentModel.DataAnnotations;

namespace GymTestDL.Models
{
    public class TimeSlotEF
    {
        [Key]
        public int TimeSlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string PartOfDay { get; set; }

        // Navigation Properties
        public ICollection<ReservationEF> Reservations { get; set; }
    }

}
