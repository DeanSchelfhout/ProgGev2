using System.ComponentModel.DataAnnotations;

namespace GymTestDL.Models
{
    public class RunningSessionMainEF
    {
        public RunningSessionMainEF() { }
        public RunningSessionMainEF(int runningSessionId, DateTime date, int memberId, TimeSpan duration, float avgSpeed, ICollection<RunningSessionDetailEF> details)
        {
            RunningSessionId = runningSessionId;
            Date = date;
            MemberId = memberId;
            Duration = duration;
            AvgSpeed = avgSpeed;
            Details = details;
        }

        [Key]
        public int RunningSessionId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public TimeSpan Duration { get; set; }
        public float AvgSpeed { get; set; }

        // Navigation Properties
        public MemberEF Member { get; set; }
        public ICollection<RunningSessionDetailEF> Details { get; set; }
    }

}
