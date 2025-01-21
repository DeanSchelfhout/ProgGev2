using GymTestDL.Models;
using Microsoft.EntityFrameworkCore;

namespace GymTestDL
{
    public class GymTestContext : DbContext
    {
        public DbSet<CyclingSessionEF> CyclingSessions { get; set; }
        public DbSet<EquipmentEF> Equipment { get; set; }
        public DbSet<MemberEF> Members { get; set; }
        public DbSet<DailyReservationEF> DailyReservations { get; set; }
        public DbSet<ProgramModelEF> ProgramModels { get; set; }
        public DbSet<ReservationEF> Reservations { get; set; }
        public DbSet<RunningSessionDetailEF> RunningSessionDetails { get; set; }
        public DbSet<RunningSessionMainEF> RunningSessionMains { get; set; }
        public DbSet<TimeSlotEF> TimeSlots { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8MGSS95;Initial Catalog=GymTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
