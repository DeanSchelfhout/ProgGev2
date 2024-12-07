namespace GymTestBL.Models
{
    public class RunningSessionDetail
    {
        public RunningSessionDetail(int runningSessionId, int seqNr, TimeSpan intervalTime, float intervalSpeed)
        {
            RunningSessionId = runningSessionId;
            SeqNr = seqNr;
            IntervalTime = intervalTime;
            IntervalSpeed = intervalSpeed;
        }

        public int RunningSessionId { get; set; }
        public int SeqNr { get; set; }
        public TimeSpan IntervalTime { get; set; }
        public float IntervalSpeed { get; set; }
    }

}
