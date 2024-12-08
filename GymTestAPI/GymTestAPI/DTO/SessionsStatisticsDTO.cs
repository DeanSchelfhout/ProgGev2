using GymTestBL.Models;

namespace GymTestAPI.DTO
{
    public class SessionsStatisticsDTO
    {   
        public int SessionCount { get; set; }
        public int TotalHourCount { get; set; }
        public double AvgSessionTime { get; set; }
        public object ShortestSession {  get; set; }
        public object LongestSession { get; set; }
    }
}
