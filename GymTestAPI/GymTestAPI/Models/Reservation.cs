namespace GymTestAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }

        public Equipment Equipment { get; set; }  
        public TimeSlot TimeSlot { get; set; }  
        public Member Member { get; set; }
    }
}
