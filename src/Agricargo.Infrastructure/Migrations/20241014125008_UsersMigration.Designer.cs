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
    [Migration("20241014125008_UsersMigration")]
    partial class UsersMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Agricargo.Domain.Entities.Ship", b =>
                {
                    b.Property<int>("ShipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Capacity")
                        .HasColumnType("REAL");

                    b.Property<string>("Captain")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeShip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ShipId");

                    b.ToTable("Ships");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
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
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.Company", b =>
                {
                    b.HasBaseType("Agricargo.Domain.Entities.User");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Agricargo.Domain.Entities.SuperAdmin", b =>
                {
                    b.HasBaseType("Agricargo.Domain.Entities.User");

                    b.HasDiscriminator().HasValue("SuperAdmin");
                });
#pragma warning restore 612, 618
        }
    }
}