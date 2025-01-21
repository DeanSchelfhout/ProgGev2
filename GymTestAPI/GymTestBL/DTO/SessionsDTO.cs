using GymTestBL.Models;

namespace GymTestBL.DTO
{
    public class SessionsDTO
    {
        public List<CyclingSession>CyclingSessions {  get; set; }
        public List<RunningSessionMain> runningSessions { get; set; }
    }
}
