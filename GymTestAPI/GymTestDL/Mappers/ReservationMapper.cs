using GymTestBL.Models;
using GymTestDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Mappers
{
    public class ReservationMapper
    {
        public static Reservation MapToBL(ReservationEF db)
        {
            try
            {
                return new Reservation(
                    db.ReservationId,
                    db.EquipmentId,
                    db.TimeSlotId,
                    db.Date,
                    db.MemberId,
                    db.TimeSlot != null ? TimeSlotMapper.MapToBL(db.TimeSlot) : new TimeSlot(),
                    db.Equipment != null ? EquipmentMapper.MapToBL(db.Equipment) : new Equipment()
                    );
            }
            catch (Exception)
            {
                throw new Exception("MapReservation - MapToBL");
            }
        }
        public static ReservationEF MapToDL(Reservation r)
        {
            try
            {
                return new ReservationEF(
                    r.ReservationId,
                    r.EquipmentId,
                    r.TimeSlotId,
                    r.Date,
                    r.MemberId,
                    r.Timeslot != null? TimeSlotMapper.MapToDL(r.Timeslot) : new TimeSlotEF(),
                    r.Equipment != null ? EquipmentMapper.MapToDL(r.Equipment) : new EquipmentEF()
                   );
            }
            catch (Exception)
            {

                throw new Exception("MapReservation - MapToDL");
            }
        }
    }
}
