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
        public void Add(DailyReservation dailyReservation);
        public bool Delete(int id);
        public DailyReservation Get(int id);
        public TimeSlot GetReservationTimeSlot(Reservation reservation);
        public (Reservation reservationDB, Equipment equipment, TimeSlot timeSlot,
        List<Reservation> existingReservations, List<Reservation> equipmentReservations,
        List<Reservation> equipmentReservationsMember, List<TimeSlot> timeslots)
        ReservationData(Reservation reservation);

    }
}
