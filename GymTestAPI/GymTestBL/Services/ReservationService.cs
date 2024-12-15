using GymTestBL.Interfaces;
using GymTestBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestBL.Services
{
    public class ReservationService
    {
        private IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository reservationRepository)
        {
            this._reservationRepository = reservationRepository;
        }
        public bool Delete(int id)
        {
            try
            {
                _reservationRepository.Delete(id);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("DeleteReservation", ex);
            }
        }
        public Reservation Add(Reservation reservation)
        {
            try
            {
                if (reservation == null) throw new Exception("AddReservation - reservation is null");
                return _reservationRepository.Add(reservation);
            }
            catch (Exception ex)
            {

                throw new Exception("AddReservation", ex);
            }
        }
        public Reservation Update(Reservation reservation)
        {
            try
            {
                if (reservation == null) throw new Exception("UpdateReservation - reservation is null");
                _reservationRepository.Update(reservation);
                return reservation;
            }
            catch (Exception ex)
            {

                throw new Exception("UpdateReservation", ex);
            }
        }
    }
}
