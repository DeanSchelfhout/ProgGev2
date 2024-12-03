namespace GymTestAPI.Models
{
    public class RunningSessionDetail
    {
        public int RunningSessionId { get; set; }
        public int SeqNr { get; set; }
        public TimeSpan IntervalTime { get; set; }
        public float IntervalSpeed { get; set; }

        // Navigation Properties
        public RunningSessionMain RunningSessionMain { get; set; }
    }

}
