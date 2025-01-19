namespace GymTestBL.Models
{
    public class RunningSessionDetail
    {
        public RunningSessionDetail()
        {
        }

        public RunningSessionDetail(int runningSessionId, int seqNr, List<TimeSpan> intervalTimes, List<float> intervalSpeeds)
        {
            RunningSessionId = runningSessionId;
            SeqNr = seqNr;
            IntervalTimes = intervalTimes;
            IntervalSpeeds = intervalSpeeds;
        }

        public int RunningSessionId { get; set; }
        public int SeqNr { get; set; }
        public List<TimeSpan> IntervalTimes { get; set; }
        public List<float> IntervalSpeeds { get; set; }
    }

}
