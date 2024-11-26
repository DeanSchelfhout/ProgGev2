using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        [HttpGet]
        public string GetAll()
        {
            return "fuck you maite";
        }
    }
}
