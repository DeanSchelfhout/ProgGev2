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
        public DailyReservation Get(int id)
        {
            try
            {
              return _reservationRepository.Get(id);
            }
            catch (Exception ex)
            {

                throw new Exception("GetReservation", ex);
            }
        }
        public void Add(DailyReservation dailyReservation)
        {
            List<Reservation> checkedReservations = new List<Reservation>();
            foreach (var reservation in dailyReservation.Reservations)
            {


                if (reservation == null) throw new Exception("AddReservation - reservation is null");

                if (reservation.Date > DateTime.Now.AddDays(7))
                {
                    throw new Exception("Reservation cannot be more than 7 days in the future");
                }

                (var reservationDB, var equipment, var timeSlot, var existingReservations, var equipmentReservations, var equipmentReservationsMember, var timeslots) = _reservationRepository.ReservationData(reservation);

                if (checkedReservations.Count > 0)
                {
                    foreach (var checkedReservation in checkedReservations)
                    {
                        existingReservations.Add(checkedReservation);
                        if(checkedReservation.EquipmentId == reservation.EquipmentId)
                        {
                            equipmentReservations.Add(checkedReservation);
                            equipmentReservationsMember.Add(checkedReservation);
                            var checkedTimeSlot = _reservationRepository.GetReservationTimeSlot(checkedReservation);
                            timeslots.Add(checkedTimeSlot);
                        }
                    }
                }
                
                if (equipment == null)
                {
                    throw new Exception("Equipment is null");
                }

                if (equipment.IsInService)
                {
                    throw new Exception("Equiptment is in service");
                }

                if (timeSlot == null)
                {
                    throw new Exception("Timeslot is null");
                }

                if (existingReservations.Count >= 4)
                {
                    throw new Exception("You can only have 4 reservations per day");
                }

                if (equipmentReservations.Any(r => r.TimeSlotId == reservation.TimeSlotId))
                {
                    throw new Exception("This equipment is already reserved for this timeslot");
                }

                if (existingReservations.Any(r => r.TimeSlotId == reservation.TimeSlotId))
                {
                    throw new Exception("You already have a reservation for this timeslot");
                }

                timeslots.Add(timeSlot);
                timeslots = timeslots.OrderBy(t => t.StartTime).ToList();

                int count = 0;
                for (int i = 0; i < timeslots.Count - 1; i++)
                {
                    if (timeslots[i].EndTime == timeslots[i + 1].StartTime)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    if (count >= 2)
                    {
                        throw new Exception("You can only have 2 consecutive reservations for this equipment");
                    }
                }
                checkedReservations.Add(reservation);
            }
                _reservationRepository.Add(dailyReservation);
        }
        public Reservation Update(Reservation reservation)
        {
            try
            {
                if (reservation == null) throw new Exception("AddReservation - reservation is null");

                if (reservation.Date > DateTime.Now.AddDays(7))
                {
                    throw new Exception("Reservation cannot be more than 7 days in the future");
                }

                (var reservationDB,var equipment, var timeSlot, var existingReservations, var equipmentReservations, var equipmentReservationsMember, var timeslots) = _reservationRepository.ReservationData(reservation);

                if (reservationDB == null)
                {
                    throw new Exception("UpdateReservation - Reservation is null");
                }

                if (reservation.Date > DateTime.Now.AddDays(7))
                {
                    throw new Exception("Reservation cannot be more than 7 days in the future");
                }

                if (equipment == null)
                {
                    throw new Exception("Equipment is null");
                }

                if (equipment.IsInService)
                {
                    throw new Exception("Equiptment is in service");
                }

                if (timeSlot == null)
                {
                    throw new Exception("Timeslot is null");
                }

                if (equipmentReservations.Any(r => r.TimeSlotId == reservation.TimeSlotId))
                {
                    throw new Exception("This equipment is already reserved for this timeslot");
                }

                if (existingReservations.Any(r => r.TimeSlotId == reservation.TimeSlotId))
                {
                    throw new Exception("You already have a reservation for this timeslot");
                }

                timeslots.Add(timeSlot);
                timeslots = timeslots.OrderBy(t => t.StartTime).ToList();

                int count = 0;
                for (int i = 0; i < timeslots.Count - 1; i++)
                {
                    if (timeslots[i].EndTime == timeslots[i + 1].StartTime)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    if (count >= 2)
                    {
                        throw new Exception("You can only have 2 consecutive reservations for this equipment");
                    }
                }

                _reservationRepository.Update(reservation,reservationDB);
                return reservation;
            }
            catch (Exception ex)
            {

                throw new Exception("UpdateReservation", ex);
            }
        }
    }
}
