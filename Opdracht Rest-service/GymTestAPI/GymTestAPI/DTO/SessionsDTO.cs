using GymTestBL.Models;

namespace GymTestAPI.DTO
{
    public class SessionsDTO
    {
        public List<CyclingSession>CyclingSessions {  get; set; }
        public List<RunningSessionMain> runningSessions { get; set; }
    }
}
