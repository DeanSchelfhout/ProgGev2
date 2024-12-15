using GymTestBL.Models;
using GymTestBL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunningSessionController : ControllerBase
    {
        RunningSessionService RepoService;
        public RunningSessionController(RunningSessionService runningSessionService)
        {
            RepoService = runningSessionService;
        }

        [Route("GetRunningSession/{id}")]
        [HttpGet]
        public RunningSessionMain Get(int id)
        {
            return RepoService.GetRunningSession(id);
        }
    }
}
