using System.ComponentModel.DataAnnotations;

namespace GymTestBL.Models
{
    public class RunningSessionMain
    {
        public RunningSessionMain(int runningSessionId, DateTime date, int memberId, TimeSpan duration, float avgSpeed)
        {
            RunningSessionId = runningSessionId;
            Date = date;
            MemberId = memberId;
            Duration = duration;
            AvgSpeed = avgSpeed;
        }
        [Key]
        public int RunningSessionId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public TimeSpan Duration { get; set; }
        public float AvgSpeed { get; set; }
    }

}
