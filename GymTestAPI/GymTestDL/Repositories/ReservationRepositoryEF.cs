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
        public Reservation Update(Reservation reservation,Reservation reservationDB)
        {
            try
            {
                ReservationEF reservationEF = ReservationMapper.MapToDL(reservationDB);
                _context.Entry(reservationEF).CurrentValues.SetValues(ReservationMapper.MapToDL(reservation));
                _context.SaveChanges();

                return ReservationMapper.MapToBL(reservationEF);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateReservation", ex);
            }
        }
        public DailyReservation Get(int id)
        {
            try
            {
                var reservation = _context.DailyReservations.Include(r => r.Reservations).FirstOrDefault(r => r.Id == id);
                return DailyReservationMapper.MapToBL(reservation);
            }
            catch (Exception ex)
            {
                throw new Exception("GetReservation", ex);
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
            catch (Exception ex)
            {
                throw new Exception("DeleteReservation",ex);
            }
        }
        public TimeSlot GetReservationTimeSlot(Reservation reservation)
        {
            var timeslotEF = _context.TimeSlots.FirstOrDefault(t => t.TimeSlotId == reservation.TimeSlotId);
            var timeSlot = timeslotEF != null ? TimeSlotMapper.MapToBL(timeslotEF) : null;

            return timeSlot;
        }
        public (Reservation reservationDB, Equipment equipment, TimeSlot timeSlot, List<Reservation> existingReservations, List<Reservation> equipmentReservations, List<Reservation> equipmentReservationsMember, List<TimeSlot> timeslots) ReservationData(Reservation reservation)
        {
            var equipmentEF = _context.Equipment.FirstOrDefault(e => e.EquipmentId == reservation.EquipmentId);
            var timeSlotEF = _context.TimeSlots.FirstOrDefault(t => t.TimeSlotId == reservation.TimeSlotId);
            var existingReservationsEF = _context.Reservations
                .Where(r => r.MemberId == reservation.MemberId && r.Date.Date == reservation.Date.Date)
                .ToList();
            var equipmentReservationsEF = _context.Reservations
                .Where(r => r.EquipmentId == reservation.EquipmentId && r.Date.Date == reservation.Date.Date)
                .ToList();
            var equipmentReservationsMemberEF = _context.Reservations
                .Where(r => r.EquipmentId == reservation.EquipmentId && r.Date.Date == reservation.Date.Date && r.MemberId == reservation.MemberId)
                .ToList();

            var equipment = equipmentEF != null ? EquipmentMapper.MapToBL(equipmentEF) : null;
            var timeSlot = timeSlotEF != null ? TimeSlotMapper.MapToBL(timeSlotEF) : null;
            var existingReservations = existingReservationsEF.Select(ReservationMapper.MapToBL).ToList();
            var equipmentReservations = equipmentReservationsEF.Select(ReservationMapper.MapToBL).ToList();
            var equipmentReservationsMember = equipmentReservationsMemberEF.Select(ReservationMapper.MapToBL).ToList();

            var timeslots = equipmentReservationsMemberEF
                .Select(r => _context.TimeSlots.FirstOrDefault(t => t.TimeSlotId == r.TimeSlotId))
                .Where(t => t != null)
                .Select(TimeSlotMapper.MapToBL)
                .ToList();

            var reservationEF = _context.Reservations.Find(reservation.ReservationId);
            var reservationDB = reservationEF != null ? ReservationMapper.MapToBL(reservationEF) : null;

            return (reservationDB, equipment, timeSlot, existingReservations, equipmentReservations, equipmentReservationsMember, timeslots);
        }

        public void Add(DailyReservation dailyReservation)
        {
            try
            {
                var dailyReservationEF = DailyReservationMapper.MapToDL(dailyReservation);
                dailyReservationEF.Id = 0;
                _context.DailyReservations.Add(dailyReservationEF);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("AddReservation", ex);
            }
        }

    }
}
