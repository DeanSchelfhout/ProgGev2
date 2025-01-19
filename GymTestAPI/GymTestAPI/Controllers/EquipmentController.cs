using GymTestAPI.DTO;
using GymTestBL.Models;
using GymTestBL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        EquipmentService RepoService;
        public EquipmentController(EquipmentService equipmentService)
        {
            RepoService = equipmentService;
        }

        [HttpGet]
        public List<Equipment> GetEquipment()
        {
            return RepoService.GetAllEquipment();
        }

        [HttpPost]
        public Equipment Add([FromBody] Equipment dataIn)
        {
            Equipment equipment = new Equipment
                (
                dataIn.EquipmentId,
                dataIn.DeviceType,
                dataIn.IsInService
                );

            return RepoService.AddEquipment(equipment);
        }
        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            RepoService.DeleteEquipment(id);
            return true;
        }
        [Route("{id}")]
        [HttpPut]
        public bool ToggleService(int id)
        {
            RepoService.ToggleInService(id);
            return true;
        }
    }
}
