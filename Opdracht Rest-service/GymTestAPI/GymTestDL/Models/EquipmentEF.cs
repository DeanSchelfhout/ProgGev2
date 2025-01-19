using System.ComponentModel.DataAnnotations;

namespace GymTestDL.Models
{
    public class EquipmentEF
    {
        public EquipmentEF()
        {
        }

        public EquipmentEF(int equipmentId, string deviceType, bool isInService)
        {
            EquipmentId = equipmentId;
            DeviceType = deviceType;
            IsInService = isInService;
        }

        [Key]
        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }
        public bool IsInService { get; set; }

        // Navigation Properties
        public ICollection<ReservationEF> Reservations { get; set; }
    }

}
