using GymTestAPI.Models;
using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection.Emit;
namespace GymTestAPI
{

    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options) : base(options) { }

        public DbSet<CyclingSession> Cyclingsessions { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ProgramModel> Programs { get; set; }
        public DbSet<ProgramMember> ProgramMembers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RunningSessionDetail> RunningSessionDetails { get; set; }
        public DbSet<RunningSessionMain> RunningSessionMains { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optionele configuraties
            modelBuilder.Entity<CyclingSession>().ToTable("cyclingsession");
            modelBuilder.Entity<Equipment>().ToTable("equipment");
            modelBuilder.Entity<Member>().ToTable("members");
            modelBuilder.Entity<ProgramModel>().ToTable("program");
            modelBuilder.Entity<ProgramMember>().ToTable("programmembers");
            modelBuilder.Entity<Reservation>().ToTable("eeservation");
            modelBuilder.Entity<RunningSessionDetail>().ToTable("running_session_detail");
            modelBuilder.Entity<RunningSessionMain>().ToTable("running_session_main");
            modelBuilder.Entity<TimeSlot>().ToTable("time_slot");
        }
    }
}
