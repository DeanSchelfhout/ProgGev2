namespace GymTestBL.DTO
{
    public class SessionCountByMonthDetailedDTO
    {
        public string Month { get; set; }
        public int CyclingSessionCount { get; set; }
        public int RunningSessionCount { get; set; }
        public int FunCount { get; set; } = 0;
        public int EnduranceCount { get; set;} = 0;
        public int IntervalCount { get; set; } = 0;
        public int RecoveryCount { get; set;} = 0;
    }
}
