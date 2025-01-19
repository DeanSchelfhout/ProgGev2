using GymTestAPI.DTO;
using GymTestBL.Models;
using GymTestBL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        ProgramService RepoService;
        public ProgramController(ProgramService programService)
        {
            RepoService = programService;
        }

        [HttpPost]
        public ProgramModel Add([FromBody] ProgramModel dataIn)
        {
            ProgramModel programModel = new ProgramModel
                (
                0,
                dataIn.Name,
                dataIn.Target,
                dataIn.StartDate,
                dataIn.MaxMembers
                );

            return RepoService.AddProgram(programModel);
        }
        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            RepoService.DeleteProgram(id);
            return true;
        }
        [Route("{id}")]
        [HttpPut]
        public ProgramModel Update(int id, [FromBody] ProgramModel dataIn)
        {
            ProgramModel programModel = new ProgramModel
                (
                id,
                dataIn.Name,
                dataIn.Target,
                dataIn.StartDate,
                dataIn.MaxMembers
                );

            return RepoService.UpdateProgram(programModel);
        }
    }
}
