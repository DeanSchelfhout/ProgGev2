using GymTestBL.Models;
using GymTestDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Mappers
{
    public static class TimeSlotMapper
    {
        public static TimeSlot MapToBL(TimeSlotEF db)
        {
            try
            {
                return new TimeSlot(
                    db.TimeSlotId,
                    db.StartTime,
                    db.EndTime, 
                    db.PartOfDay
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("MapTimeSlot - MapToBL", ex);
            }
        }
        public static TimeSlotEF MapToDL(TimeSlot t)
        {
            try
            {
                return new TimeSlotEF(
                    t.TimeSlotId,
                    t.StartTime,
                    t.EndTime,
                    t.PartOfDay
                   );
            }
            catch (Exception ex)
            {

                throw new Exception("MapTimeSlot - MapToDL", ex);
            }
        }
    }
}
