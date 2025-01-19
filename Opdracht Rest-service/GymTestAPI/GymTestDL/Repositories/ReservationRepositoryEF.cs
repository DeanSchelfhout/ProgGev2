using GymTestBL.Interfaces;
using GymTestBL.Models;
using GymTestDL.Mappers;
using GymTestDL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Repositories
{
    public class ReservationRepositoryEF : IReservationRepository
    {
        private GymTestContext _context;
        public ReservationRepositoryEF(GymTestContext context)
        {
            _context = context;
        }
        public Reservation Update(Reservation reservation)
        {
            try
            {
                var reservationDB = _context.Reservations.Find(reservation.ReservationId);
                if (reservationDB == null)
                {
                    throw new Exception("UpdateReservation - Reservation is null");
                }

                if (reservation.Date > DateTime.Now.AddDays(7))
                {
                    throw new Exception("Reservation cannot be more than 7 days in the future");
                }

                var equipment = _context.Equipment.FirstOrDefault(e => e.EquipmentId == reservation.EquipmentId);
                if (equipment == null)
                {
                    throw new Exception("Equipment is null");
                }

                if (equipment.IsInService)
                {
                    throw new Exception("Equiptment is in service");
                }

                var timeSlot = _context.TimeSlots.FirstOrDefault(t => t.TimeSlotId == reservation.TimeSlotId);
                if (timeSlot == null)
                {
                    throw new Exception("Timeslot is null");
                }

                var equipmentReservations = _context.Reservations.Where(r => r.EquipmentId == reservation.EquipmentId && r.Date.Date == reservation.Date.Date).ToList();

                if (equipmentReservations.Any(r => r.TimeSlotId == reservation.TimeSlotId))
                {
                    throw new Exception("This equipment is already reserved for this timeslot");
                }

                equipmentReservations = _context.Reservations.Where(r => r.EquipmentId == reservation.EquipmentId && r.Date.Date == reservation.Date.Date && r.MemberId == reservation.MemberId).ToList();
                var timeslots = equipmentReservations.Select(r => _context.TimeSlots.FirstOrDefault(t => t.TimeSlotId == r.TimeSlotId)).ToList();

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

                _context.Entry(reservationDB).CurrentValues.SetValues(ReservationMapper.MapToDL(reservation));
                _context.SaveChanges();

                return ReservationMapper.MapToBL(reservationDB);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateReservation", ex);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _context.Reservations.Remove(new ReservationEF() { ReservationId = id });
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw new Exception("DeleteReservation");
            }
        }
        public Reservation Add(Reservation reservation)
        {
            try
            {
                if (reservation.Date > DateTime.Now.AddDays(7))
                {
                    throw new Exception("Reservation cannot be more than 7 days in the future");
                }

                var equipment = _context.Equipment.FirstOrDefault(e => e.EquipmentId == reservation.EquipmentId);
                if (equipment == null)
                {
                    throw new Exception("Equipment is null");
                }

                if (equipment.IsInService)
                {
                    throw new Exception("Equiptment is in service");
                }

                var timeSlot = _context.TimeSlots.FirstOrDefault(t => t.TimeSlotId == reservation.TimeSlotId);
                if (timeSlot == null)
                {
                    throw new Exception("Timeslot is null");
                }

                var existingReservations = _context.Reservations
                .Where(r => r.MemberId == reservation.MemberId && r.Date.Date == reservation.Date.Date)
                .ToList();


                if (existingReservations.Count >= 4)
                {
                    throw new Exception("You can only have 4 reservations per day");
                }

                var equipmentReservations = _context.Reservations.Where(r => r.EquipmentId == reservation.EquipmentId && r.Date.Date == reservation.Date.Date).ToList();

                if (equipmentReservations.Any(r => r.TimeSlotId == reservation.TimeSlotId))
                {
                    throw new Exception("This equipment is already reserved for this timeslot");
                }

                equipmentReservations = _context.Reservations.Where(r => r.EquipmentId == reservation.EquipmentId && r.Date.Date == reservation.Date.Date && r.MemberId == reservation.MemberId).ToList();
                var timeslots = equipmentReservations.Select(r => _context.TimeSlots.FirstOrDefault(t => t.TimeSlotId == r.TimeSlotId)).ToList();

                timeslots.Add(timeSlot);
                timeslots = timeslots.OrderBy(t => t.StartTime).ToList();

                int count = 0;
                for (int i = 0; i < timeslots.Count-1; i++)
                {
                    if (timeslots[i].EndTime == timeslots[i +1].StartTime)
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



                var reservationDB = ReservationMapper.MapToDL(reservation);
                _context.Reservations.Add(reservationDB);
                _context.SaveChanges();

                return ReservationMapper.MapToBL(reservationDB);
            }
            catch (Exception ex)
            {
                throw new Exception("AddReservation", ex);
            }
        }

    }
}
