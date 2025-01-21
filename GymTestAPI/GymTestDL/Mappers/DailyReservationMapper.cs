using GymTestBL.Models;
using GymTestDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymTestBL.Models.Member;

namespace GymTestDL.Mappers
{
    public static class DailyReservationMapper
    {
        public static DailyReservation MapToBL(DailyReservationEF db)
        {
            try
            {
                return new DailyReservation(
                    db.Date,
                    db.Reservations?.Select(ReservationMapper.MapToBL).ToList() ?? new List<Reservation>());
            }
            catch (Exception)
            {
                throw new Exception("MapDailyReservation - MapToBL");
            }
        }
        public static DailyReservationEF MapToDL(DailyReservation m)
        {
            try
            {
                return new DailyReservationEF(
                    m.MemberId,
                    m.Date,
                    m.Reservations?.Select(ReservationMapper.MapToDL).ToList() ?? new List<ReservationEF>());
            }
            catch (Exception)
            {

                throw new Exception("MapDailyReservation - MapToDL");
            }
        }
    }
}
