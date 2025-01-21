using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestBL.Models
{
    public class DailyReservation
    {
        public DailyReservation()
        {
        }

        public DailyReservation(DateTime date, ICollection<Reservation> reservations)
        {
            Date = date;
            Reservations = reservations;
        }

        public DailyReservation(int memberId, DateTime date, ICollection<Reservation> reservations)
        {
            MemberId = memberId;
            Date = date;
            Reservations = reservations;
        }

        public int MemberId { get; set; }

        public DateTime Date { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
