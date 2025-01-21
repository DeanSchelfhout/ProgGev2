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

        [HttpPost]
        public IActionResult Add([FromBody] DailyReservationDTO dataIn)
        {
            try
            {
                if(
                    (dataIn.EquipmentId1 == 0 && dataIn.TimeSlotId1 == 0) &&
                    (dataIn.EquipmentId2 == 0 && dataIn.TimeSlotId2 == 0) &&
                    (dataIn.EquipmentId3 == 0 && dataIn.TimeSlotId3 == 0) &&
                    (dataIn.EquipmentId4 == 0 && dataIn.TimeSlotId4 == 0)
                    )
                {
                    return BadRequest(new { message = "Invallid reservation" });
                }

                DailyReservation dailyReservation = new DailyReservation();
                dailyReservation.MemberId = dataIn.MemberId;
                dailyReservation.Date = dataIn.Date;
                List<Reservation> reservations = new List<Reservation>();
                

                if (dataIn.EquipmentId1 != 0 && dataIn.TimeSlotId1 != 0)
                {
                    Reservation reservation = new Reservation();
                    reservation.ReservationId = 0;
                    reservation.MemberId = dataIn.MemberId;
                    reservation.Date = dataIn.Date;
                    reservation.TimeSlotId = dataIn.TimeSlotId1;
                    reservation.EquipmentId = dataIn.EquipmentId1;
                    reservations.Add(reservation);
                }
                if (dataIn.EquipmentId2 != 0 && dataIn.TimeSlotId2 != 0)
                {
                    Reservation reservation = new Reservation();
                    reservation.ReservationId = 0;
                    reservation.MemberId = dataIn.MemberId;
                    reservation.Date = dataIn.Date;
                    reservation.TimeSlotId = dataIn.TimeSlotId2;
                    reservation.EquipmentId = dataIn.EquipmentId2;
                    reservations.Add(reservation);
                }
                if (dataIn.EquipmentId3 != 0 && dataIn.TimeSlotId3 != 0)
                {
                    Reservation reservation = new Reservation();
                    reservation.ReservationId = 0;
                    reservation.MemberId = dataIn.MemberId;
                    reservation.Date = dataIn.Date;
                    reservation.TimeSlotId = dataIn.TimeSlotId3;
                    reservation.EquipmentId = dataIn.EquipmentId3;
                    reservations.Add(reservation);
                }
                if (dataIn.EquipmentId4 != 0 && dataIn.TimeSlotId4 != 0)
                {
                    Reservation reservation = new Reservation();
                    reservation.ReservationId = 0;
                    reservation.MemberId = dataIn.MemberId;
                    reservation.Date = dataIn.Date;
                    reservation.TimeSlotId = dataIn.TimeSlotId4;
                    reservation.EquipmentId = dataIn.EquipmentId4;
                    reservations.Add(reservation);
                }
                dailyReservation.Reservations = reservations;

                RepoService.Add(dailyReservation);
                return Ok("OK");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            RepoService.Delete(id);
            return true;
        }
        [Route("{id}")]
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
