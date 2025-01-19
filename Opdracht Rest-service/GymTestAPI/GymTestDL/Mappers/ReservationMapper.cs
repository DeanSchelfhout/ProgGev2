using GymTestBL.Models;
using GymTestDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Mappers
{
    public static class ReservationMapper
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
                    db.MemberId
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
                    r.MemberId
                   );
            }
            catch (Exception)
            {

                throw new Exception("MapReservation - MapToDL");
            }
        }
    }
}
