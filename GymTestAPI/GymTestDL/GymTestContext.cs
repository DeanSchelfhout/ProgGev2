using GymTestDL.Models;
using Microsoft.EntityFrameworkCore;

namespace GymTestDL
{
    public class GymTestContext : DbContext
    {
        public DbSet<CyclingSessionEF> CyclingSessions { get; set; }
        public DbSet<EquipmentEF> Equipment { get; set; }
        public DbSet<MemberEF> Members { get; set; }
        public DbSet<ProgramMemberEF> ProgramMembers { get; set; }
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
            optionsBuilder.UseSqlServer(@"Data Source=Dean_MSI\SQLEXPRESS;Initial Catalog=GymTest;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
