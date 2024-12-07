using System.ComponentModel.DataAnnotations;

namespace GymTestDL.Models
{
    public class TimeSlotEF
    {
        public TimeSlotEF()
        {
        }

        public TimeSlotEF(int timeSlotId, TimeSpan startTime, TimeSpan endTime, string partOfDay)
        {
            TimeSlotId = timeSlotId;
            StartTime = startTime;
            EndTime = endTime;
            PartOfDay = partOfDay;
        }

        [Key]
        public int TimeSlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string PartOfDay { get; set; }

        // Navigation Properties
        public ICollection<ReservationEF> Reservations { get; set; }
    }

}
