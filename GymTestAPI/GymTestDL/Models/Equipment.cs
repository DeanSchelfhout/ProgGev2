namespace GymTestAPI.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }

        // Navigation Properties
        public ICollection<Reservation> Reservations { get; set; }
    }

}
