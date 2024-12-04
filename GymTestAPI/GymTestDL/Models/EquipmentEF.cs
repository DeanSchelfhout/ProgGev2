namespace GymTestDL.Models
{
    public class EquipmentEF
    {
        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }

        // Navigation Properties
        public ICollection<ReservationEF> Reservations { get; set; }
    }

}
