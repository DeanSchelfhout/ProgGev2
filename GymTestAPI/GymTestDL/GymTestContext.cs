using GymTestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GymTestDL
{
    public class GymTestContext : DbContext
    {
        public DbSet<CyclingSession> CyclingSessions { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ProgramMember> ProgramMembers { get; set; }
        public DbSet<ProgramModel> ProgramModels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RunningSessionDetail> RunningSessionDetails { get; set; }
        public DbSet<RunningSessionMain> RunningSessionMains { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Dean_MSI\SQLEXPRESS;Initial Catalog=GymTest;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(memberBuilder =>
            {
                memberBuilder.HasKey(m => m.MemberId);

                memberBuilder
                .HasMany(m => m.RunningSessions)
                .WithOne()
                .HasForeignKey("member_id");

                memberBuilder
                    .HasMany(m => m.ProgramMembers)
                    .WithOne()
                    .HasForeignKey("member_id");
                memberBuilder
                .HasMany(m => m.Reservations)
                .WithOne()
                .HasForeignKey("member_id");
            }
            );
            // Member and Running Sessions
            modelBuilder.Entity<RunningSessionMain>()
                .HasOne(r => r.Member)
                .WithMany(m => m.RunningSessions)
                .HasForeignKey(r => r.MemberId);

            modelBuilder.Entity<RunningSessionDetail>()
                .HasKey(r => new { r.RunningSessionId, r.SeqNr });

            modelBuilder.Entity<RunningSessionDetail>()
                .HasOne(r => r.RunningSessionMain)
                .WithMany(r => r.Details)
                .HasForeignKey(r => r.RunningSessionId);

            // Member and Cycling Sessions
            modelBuilder.Entity<CyclingSession>()
                .HasOne(c => c.Member)
                .WithMany(m => m.CyclingSessions)
                .HasForeignKey(c => c.MemberId);

            // Reservations
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Member)
                .WithMany(m => m.Reservations)
                .HasForeignKey(r => r.MemberId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.TimeSlot)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TimeSlotId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Equipment)
                .WithMany(e => e.Reservations)
                .HasForeignKey(r => r.EquipmentId);

            // Members and Programs
            modelBuilder.Entity<ProgramMember>()
                .HasKey(pm => new { pm.ProgramCode, pm.MemberId });

            modelBuilder.Entity<ProgramMember>()
                .HasOne(pm => pm.Program)
                .WithMany(p => p.ProgramMembers)
                .HasForeignKey(pm => pm.ProgramCode);

            modelBuilder.Entity<ProgramMember>()
                .HasOne(pm => pm.Member)
                .WithMany(m => m.ProgramMembers)
                .HasForeignKey(pm => pm.MemberId);
        }
    }
}
