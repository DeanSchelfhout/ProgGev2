using System.ComponentModel.DataAnnotations;

namespace GymTestDL.Models
{
    public class EquipmentEF
    {
        [Key]
        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }

        // Navigation Properties
        public ICollection<ReservationEF> Reservations { get; set; }
    }

}
