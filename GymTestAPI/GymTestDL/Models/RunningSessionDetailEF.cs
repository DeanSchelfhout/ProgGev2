using System.ComponentModel.DataAnnotations;

namespace GymTestDL.Models
{
    public class RunningSessionDetailEF
    {
        public RunningSessionDetailEF(int runningSessionId, int seqNr, TimeSpan intervalTime, float intervalSpeed)
        {
            RunningSessionId = runningSessionId;
            SeqNr = seqNr;
            IntervalTime = intervalTime;
            IntervalSpeed = intervalSpeed;
        }

        [Key]
        public int RunningSessionId { get; set; }
        public int SeqNr { get; set; }
        public TimeSpan IntervalTime { get; set; }
        public float IntervalSpeed { get; set; }

        // Navigation Properties
        public RunningSessionMainEF RunningSessionMain { get; set; }
    }

}
