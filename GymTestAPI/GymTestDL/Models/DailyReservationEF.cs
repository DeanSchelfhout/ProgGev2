using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Models
{
    public class DailyReservationEF
    {
        public DailyReservationEF()
        {
        }

        public DailyReservationEF(DateTime date, ICollection<ReservationEF> reservations)
        {
            Date = date;
            Reservations = reservations;
        }

        public DailyReservationEF(int memberId, DateTime date, ICollection<ReservationEF> reservations)
        {
            MemberId = memberId;
            Date = date;
            Reservations = reservations;
        }

        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public MemberEF Member{ get; set; }
        public DateTime Date{ get; set; }
        public ICollection<ReservationEF> Reservations{ get; set; }
    }
}
