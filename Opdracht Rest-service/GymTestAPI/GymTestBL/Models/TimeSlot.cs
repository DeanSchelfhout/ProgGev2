namespace GymTestBL.Models
{
    public class TimeSlot
    {
        public TimeSlot()
        {
        }

        public TimeSlot(int timeSlotId, TimeSpan startTime, TimeSpan endTime, string partOfDay)
        {
            TimeSlotId = timeSlotId;
            StartTime = startTime;
            EndTime = endTime;
            PartOfDay = partOfDay;
        }

        public int TimeSlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string PartOfDay { get; set; }
    }

}
