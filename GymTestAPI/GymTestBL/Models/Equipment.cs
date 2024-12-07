namespace GymTestBL.Models
{
    public class Equipment
    {
        public Equipment()
        {
        }

        public Equipment(int equipmentId, string deviceType, bool isInService)
        {
            EquipmentId = equipmentId;
            DeviceType = deviceType;
            IsInService = isInService;
        }

        public int EquipmentId { get; set; }
        public string DeviceType { get; set; }
        public bool IsInService { get; set; }
    }

}
