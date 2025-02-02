﻿// <auto-generated />
using System;
using GymTestDL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymTestDL.Migrations
{
    [DbContext(typeof(GymTestContext))]
    [Migration("20241207131400_Gymtest")]
    partial class Gymtest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GymTestDL.Models.CyclingSessionEF", b =>
                {
                    b.Property<int>("CyclingSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CyclingSessionId"));

                    b.Property<float>("AvgCadence")
                        .HasColumnType("real");

                    b.Property<float>("AvgWatt")
                        .HasColumnType("real");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<float>("MaxCadence")
                        .HasColumnType("real");

                    b.Property<float>("MaxWatt")
                        .HasColumnType("real");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("TrainingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CyclingSessionId");

                    b.HasIndex("MemberId");

                    b.ToTable("CyclingSessions");
                });

            modelBuilder.Entity("GymTestDL.Models.EquipmentEF", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentId"));

                    b.Property<string>("DeviceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInService")
                        .HasColumnType("bit");

                    b.HasKey("EquipmentId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("GymTestDL.Models.MemberEF", b =>
                {
                    b.Property<int?>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("MemberId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interests")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("GymTestDL.Models.ProgramModelEF", b =>
                {
                    b.Property<string>("ProgramCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MaxMembers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Target")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramCode");

                    b.ToTable("ProgramModels");
                });

            modelBuilder.Entity("GymTestDL.Models.ReservationEF", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("TimeSlotId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("MemberId");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("GymTestDL.Models.RunningSessionDetailEF", b =>
                {
                    b.Property<int>("RunningSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RunningSessionId"));

                    b.Property<float>("IntervalSpeed")
                        .HasColumnType("real");

                    b.Property<TimeSpan>("IntervalTime")
                        .HasColumnType("time");

                    b.Property<int>("RunningSessionMainRunningSessionId")
                        .HasColumnType("int");

                    b.Property<int>("SeqNr")
                        .HasColumnType("int");

                    b.HasKey("RunningSessionId");

                    b.HasIndex("RunningSessionMainRunningSessionId");

                    b.ToTable("RunningSessionDetails");
                });

            modelBuilder.Entity("GymTestDL.Models.RunningSessionMainEF", b =>
                {
                    b.Property<int>("RunningSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RunningSessionId"));

                    b.Property<float>("AvgSpeed")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.HasKey("RunningSessionId");

                    b.HasIndex("MemberId");

                    b.ToTable("RunningSessionMains");
                });

            modelBuilder.Entity("GymTestDL.Models.TimeSlotEF", b =>
                {
                    b.Property<int>("TimeSlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeSlotId"));

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("PartOfDay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("TimeSlotId");

                    b.ToTable("TimeSlots");
                });

            modelBuilder.Entity("MemberEFProgramModelEF", b =>
                {
                    b.Property<int>("MembersMemberId")
                        .HasColumnType("int");

                    b.Property<string>("ProgramsProgramCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MembersMemberId", "ProgramsProgramCode");

                    b.HasIndex("ProgramsProgramCode");

                    b.ToTable("MemberEFProgramModelEF");
                });

            modelBuilder.Entity("GymTestDL.Models.CyclingSessionEF", b =>
                {
                    b.HasOne("GymTestDL.Models.MemberEF", "Member")
                        .WithMany("CyclingSessions")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("GymTestDL.Models.ReservationEF", b =>
                {
                    b.HasOne("GymTestDL.Models.EquipmentEF", "Equipment")
                        .WithMany("Reservations")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTestDL.Models.MemberEF", "Member")
                        .WithMany("Reservations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTestDL.Models.TimeSlotEF", "TimeSlot")
                        .WithMany("Reservations")
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Member");

                    b.Navigation("TimeSlot");
                });

            modelBuilder.Entity("GymTestDL.Models.RunningSessionDetailEF", b =>
                {
                    b.HasOne("GymTestDL.Models.RunningSessionMainEF", "RunningSessionMain")
                        .WithMany("Details")
                        .HasForeignKey("RunningSessionMainRunningSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RunningSessionMain");
                });

            modelBuilder.Entity("GymTestDL.Models.RunningSessionMainEF", b =>
                {
                    b.HasOne("GymTestDL.Models.MemberEF", "Member")
                        .WithMany("RunningSessions")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("MemberEFProgramModelEF", b =>
                {
                    b.HasOne("GymTestDL.Models.MemberEF", null)
                        .WithMany()
                        .HasForeignKey("MembersMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTestDL.Models.ProgramModelEF", null)
                        .WithMany()
                        .HasForeignKey("ProgramsProgramCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymTestDL.Models.EquipmentEF", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("GymTestDL.Models.MemberEF", b =>
                {
                    b.Navigation("CyclingSessions");

                    b.Navigation("Reservations");

                    b.Navigation("RunningSessions");
                });

            modelBuilder.Entity("GymTestDL.Models.RunningSessionMainEF", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("GymTestDL.Models.TimeSlotEF", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
