﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance;

namespace Persistance.Migrations
{
    [DbContext(typeof(SchoolClassReservationDbContext))]
    [Migration("20200410150612_intialMigration")]
    partial class intialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Cours", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CoursId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("designation")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Cours");
                });

            modelBuilder.Entity("Domain.Entities.Instructor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("InstructorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nom")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("coursId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("dateReservation")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("instructorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("salleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("coursId");

                    b.HasIndex("instructorId");

                    b.HasIndex("salleId");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("Domain.Entities.Salle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SalleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("designation")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Salle");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Domain.Entities.Cours", "cours")
                        .WithMany("reservations")
                        .HasForeignKey("coursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Instructor", "instructor")
                        .WithMany("reservations")
                        .HasForeignKey("instructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Salle", "salle")
                        .WithMany("reservations")
                        .HasForeignKey("salleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
