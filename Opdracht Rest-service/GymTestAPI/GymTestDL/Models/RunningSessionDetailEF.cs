using System.ComponentModel.DataAnnotations;

namespace GymTestDL.Models
{
    public class RunningSessionDetailEF
    {
        public RunningSessionDetailEF()
        {
        }

        public RunningSessionDetailEF(int runningSessionId, int seqNr, List<TimeSpan> intervalTimes, List<float> intervalSpeeds)
        {
            RunningSessionId = runningSessionId;
            SeqNr = seqNr;
            IntervalTimes = intervalTimes;
            IntervalSpeeds = intervalSpeeds;
        }

        [Key]
        public int RunningSessionId { get; set; }
        public int SeqNr { get; set; }
        public List<TimeSpan> IntervalTimes { get; set; }
        public List<float> IntervalSpeeds { get; set; }


    }

}
