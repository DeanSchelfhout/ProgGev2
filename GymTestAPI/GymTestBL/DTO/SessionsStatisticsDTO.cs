using GymTestBL.Models;

namespace GymTestBL.DTO
{
    public class SessionsStatisticsDTO
    {   
        public int SessionCount { get; set; }
        public TimeSpan TotalHourCount { get; set; }
        public TimeSpan AvgSessionTime { get; set; }
        public object ShortestSession {  get; set; }
        public object LongestSession { get; set; }
    }
}
