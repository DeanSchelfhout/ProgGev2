using System.ComponentModel.DataAnnotations;

namespace GymTestDL.Models
{
    public class ReservationEF
    {
        public ReservationEF(int reservationId, int equipmentId, int timeSlotId, DateTime date, int memberId, TimeSlotEF timeslot,EquipmentEF equipment)
        {
            ReservationId = reservationId;
            EquipmentId = equipmentId;
            TimeSlotId = timeSlotId;
            Date = date;
            MemberId = memberId;
            TimeSlot = timeslot;
            Equipment = equipment;
        }
        [Key]
        public int ReservationId { get; set; }
        public int EquipmentId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }

        // Navigation Properties
        public EquipmentEF Equipment { get; set; }
        public TimeSlotEF TimeSlot { get; set; }
        public MemberEF Member { get; set; }
    }

}
