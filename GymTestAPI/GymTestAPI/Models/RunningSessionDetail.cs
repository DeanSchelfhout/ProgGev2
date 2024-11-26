namespace GymTestAPI.Models
{
    public class RunningSessionDetail
    {
        public int Id { get; set; }
        public int SeqNr { get; set; }
        public int IntervalTime { get; set; }
        public float IntervalSpeed { get; set; }

        public RunningSessionMain RunningSessionMain { get; set; }
    }
}
