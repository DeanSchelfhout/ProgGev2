using GymTestBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestBL.Interfaces
{
    public interface IReservationRepository
    {
        public Reservation Update(Reservation reservation, Reservation reservationDB);
        public Reservation Add(Reservation reservation);
        public bool Delete(int id);

        public (Reservation reservationDB, Equipment equipment, TimeSlot timeSlot,
        List<Reservation> existingReservations, List<Reservation> equipmentReservations,
        List<Reservation> equipmentReservationsMember, List<TimeSlot> timeslots)
        ReservationData(Reservation reservation);

    }
}
