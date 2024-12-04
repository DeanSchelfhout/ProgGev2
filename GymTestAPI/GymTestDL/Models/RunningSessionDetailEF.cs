namespace GymTestDL.Models
{
    public class RunningSessionDetailEF
    {
        public int RunningSessionId { get; set; }
        public int SeqNr { get; set; }
        public TimeSpan IntervalTime { get; set; }
        public float IntervalSpeed { get; set; }

        // Navigation Properties
        public RunningSessionMainEF RunningSessionMain { get; set; }
    }

}
