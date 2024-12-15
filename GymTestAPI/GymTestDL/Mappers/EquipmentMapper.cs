using GymTestBL.Models;
using GymTestDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Mappers
{
    public static class EquipmentMapper
    {
        public static Equipment MapToBL(EquipmentEF db)
        {
            try
            {
                return new Equipment(
                    db.EquipmentId,
                    db.DeviceType,
                    db.IsInService
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("MapEquipment - MapToBL",ex);
            }
        }
        public static EquipmentEF MapToDL(Equipment s)
        {
            try
            {
                return new EquipmentEF(
                    s.EquipmentId,
                    s.DeviceType,
                    s.IsInService
                   );
            }
            catch (Exception ex)
            {

                throw new Exception("MapEquipment - MapToDL",ex);
            }
        }
    }
}
