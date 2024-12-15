namespace GymTestAPI.DTO
{
    public class ReservationDTO
    {
        public int EquipmentId { get; set; }
        public int TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
    }
}
