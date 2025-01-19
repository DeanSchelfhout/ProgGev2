namespace GymTestBL.Models
{
    public class Reservation
    {
        public Reservation()
        {
        }

        public Reservation(int reservationId, int equipmentId, int timeSlotId, DateTime date, int memberId)
        {
            ReservationId = reservationId;
            EquipmentId = equipmentId;
            TimeSlotId = timeSlotId;
            Date = date;
            MemberId = memberId;
        }

        public Reservation(int reservationId, int equipmentId, int timeSlotId, DateTime date, int memberId,TimeSlot timeslot, Equipment equipment)
        {
            ReservationId = reservationId;
            EquipmentId = equipmentId;
            TimeSlotId = timeSlotId;
            Date = date;
            MemberId = memberId;
            Timeslot = timeslot;
            Equipment = equipment;
        }

        public int ReservationId { get; set; }
        public int EquipmentId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public Equipment Equipment { get; set; }
        public TimeSlot Timeslot { get; set; }
    }

}
