namespace GymTestAPI.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string DeviceType { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
