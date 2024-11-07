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
    [Migration("20241106004402_companyShipsJsonIgnore")]
    partial class companyShipsJsonIgnore
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
                            Id = new Guid("be9f8905-91e2-4a14-ae77-3071586d0656"),
                            Email = "pablo@gmail.com",
                            Name = "Pablo",
                            Password = "$2a$11$QFyiMCpwRFP6OFIHyGO5oOhhx2j1d7a4Wn2OzFTtaz4t4TQ35RnGi",
                            Phone = "19864343",
                            TypeUser = "Client"
                        },
                        new
                        {
                            Id = new Guid("0ca56afa-6870-4ce9-b6ce-3240e0c717a1"),
                            Email = "emi@gmail.com",
                            Name = "Emiliano",
                            Password = "$2a$11$yBGN/WXjHAI0yIOLRxb6WOiTgTrdcmImHZbQN8K04X0U1eUfwi/cq",
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
                            Id = new Guid("c095f425-3f8b-485d-b609-fd915e3c8b24"),
                            Email = "mario@gmail.com",
                            Name = "Mario Massonnat",
                            Password = "$2a$11$j8vaujxIZLZ1X7kWRNzh3ODHXZcYPp97J7iFSqHvKQpun/nYONWVe",
                            Phone = "153252",
                            TypeUser = "Admin",
                            CompanyName = "El Maruco CIA"
                        },
                        new
                        {
                            Id = new Guid("e8eb1993-5431-461d-bf8b-0a18c59ab614"),
                            Email = "pale@gmail.com",
                            Name = "Francisco Palena",
                            Password = "$2a$11$T5RbJ8AzqFYR.Hw0LbTMIuZ3P7fFZhS979t0fSaTXTkv2Im/UkXJe",
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
                            Id = new Guid("4e79be9f-83e2-485f-a6e0-27378bc601c7"),
                            Email = "sys_admin@gmail.com",
                            Name = "web master",
                            Password = "$2a$11$4O7lAj4WbyB3R5cJjquJsOLHX86TKw8ttHOlpJlpn0cYlnSSYMFL2",
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