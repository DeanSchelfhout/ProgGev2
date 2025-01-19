using GymTestAPI.DTO;
using GymTestBL.Models;
using GymTestBL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        ReservationService RepoService;
        public ReservationController(ReservationService reservationService)
        {
            RepoService = reservationService;
        }

        [Route("Add")]
        [HttpPost]
        public Reservation Add([FromBody] ReservationDTO dataIn)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationId = 0;
            reservation.EquipmentId = dataIn.EquipmentId;
            reservation.MemberId = dataIn.MemberId;
            reservation.TimeSlotId = dataIn.TimeSlotId;
            reservation.Date = dataIn.Date;

            return RepoService.Add(reservation);
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            RepoService.Delete(id);
            return true;
        }
        [Route("Update/{id}")]
        [HttpPut]
        public Reservation Update(int id, [FromBody] ReservationDTO dataIn)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationId = id;
            reservation.EquipmentId = dataIn.EquipmentId;
            reservation.MemberId = dataIn.MemberId;
            reservation.TimeSlotId = dataIn.TimeSlotId;
            reservation.Date = dataIn.Date;


            return RepoService.Update(reservation);
        }
    }
}
