﻿// <auto-generated />
using System;
using Agricargo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Agricargo.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241028195854_migrationSeeder")]
    partial class migrationSeeder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Agricargo.Domain.Entities.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<int>("TripId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("TripId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ArriveDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("TEXT");

                    b.Property<float>("PurchaseAmount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("TEXT");

                    b.Property<float>("PurchasePrice")
                        .HasColumnType("REAL");

                    b.Property<string>("ReservationStatus")
                        .HasColumnType("TEXT");

                    b.Property<int>("TripId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("TripId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Capacity")
                        .HasColumnType("REAL");

                    b.Property<string>("Captain")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShipPlate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeShip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Ships");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ArriveDate")
                        .HasColumnType("TEXT");

                    b.Property<float>("AvailableCapacity")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ShipId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TripState")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ShipId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeUser")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("TypeUser").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Client", b =>
                {
                    b.HasBaseType("Agricargo.Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7983ab63-d0ba-412d-97b2-c5170924f4fa"),
                            Email = "pablo@gmail.com",
                            Name = "Pablo",
                            Password = "pablo1234",
                            Phone = "19864343",
                            TypeUser = "Client"
                        },
                        new
                        {
                            Id = new Guid("48e4c99e-5859-4770-9d6b-8bcd8840f856"),
                            Email = "emi@gmail.com",
                            Name = "Emiliano",
                            Password = "emi1234",
                            Phone = "1923486",
                            TypeUser = "Client"
                        });
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Company", b =>
                {
                    b.HasBaseType("Agricargo.Domain.Entities.User");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = new Guid("379b0d9e-9042-4136-a4a9-12f430cea28f"),
                            Email = "mario@gmail.com",
                            Name = "Mario Massonnat",
                            Password = "mario1234",
                            Phone = "153252",
                            TypeUser = "Admin",
                            CompanyName = "El Maruco CIA"
                        },
                        new
                        {
                            Id = new Guid("0699fa36-bc12-4937-96af-899046fab1d0"),
                            Email = "pale@gmail.com",
                            Name = "Francisco Palena",
                            Password = "pale1234",
                            Phone = "1986",
                            TypeUser = "Admin",
                            CompanyName = "Pale SRL"
                        });
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.SuperAdmin", b =>
                {
                    b.HasBaseType("Agricargo.Domain.Entities.User");

                    b.HasDiscriminator().HasValue("SuperAdmin");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c09fc353-580d-4515-b3c3-10e73f64dc1b"),
                            Email = "sys_admin@gmail.com",
                            Name = "web master",
                            Password = "superadmin1234",
                            Phone = "1242214",
                            TypeUser = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Favorite", b =>
                {
                    b.HasOne("Agricargo.Domain.Entities.Client", "Client")
                        .WithMany("Favorites")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agricargo.Domain.Entities.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Agricargo.Domain.Entities.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agricargo.Domain.Entities.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Ship", b =>
                {
                    b.HasOne("Agricargo.Domain.Entities.Company", "Company")
                        .WithMany("Ships")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Trip", b =>
                {
                    b.HasOne("Agricargo.Domain.Entities.Ship", "Ship")
                        .WithMany("Trips")
                        .HasForeignKey("ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ship");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Ship", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Client", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Company", b =>
                {
                    b.Navigation("Ships");
                });
#pragma warning restore 612, 618
        }
    }
}
