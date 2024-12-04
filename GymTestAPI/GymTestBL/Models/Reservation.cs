namespace GymTestBL.Models
{
    public class Reservation
    {
        public Reservation(int reservationId, int equipmentId, int timeSlotId, DateTime date, int memberId)
        {
            ReservationId = reservationId;
            EquipmentId = equipmentId;
            TimeSlotId = timeSlotId;
            Date = date;
            MemberId = memberId;
        }

        public int ReservationId { get; set; }
        public int EquipmentId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
    }

}
