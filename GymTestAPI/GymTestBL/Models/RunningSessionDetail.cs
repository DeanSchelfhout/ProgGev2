namespace GymTestBL.Models
{
    public class RunningSessionDetail
    {
        public int RunningSessionId { get; set; }
        public int SeqNr { get; set; }
        public TimeSpan IntervalTime { get; set; }
        public float IntervalSpeed { get; set; }
    }

}
