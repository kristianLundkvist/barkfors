﻿// <auto-generated />
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(VehicleContext))]
    [Migration("20220302193442_ResetDatabase")]
    partial class ResetDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Backend.Models.Brand", b =>
                {
                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BrandName");

                    b.ToTable("BrandSet");
                });

            modelBuilder.Entity("Backend.Models.CarColor", b =>
                {
                    b.Property<string>("ColorName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ColorName");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Backend.Models.FuelType", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Type");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("Backend.Models.Vehicle", b =>
                {
                    b.Property<string>("VIN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarColorColorName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FuelTypeType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleEquipmentEquipment")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("VIN");

                    b.HasIndex("BrandName");

                    b.HasIndex("CarColorColorName");

                    b.HasIndex("FuelTypeType");

                    b.HasIndex("VehicleEquipmentEquipment");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Backend.Models.VehicleEquipment", b =>
                {
                    b.Property<string>("Equipment")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Equipment");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Backend.Models.Vehicle", b =>
                {
                    b.HasOne("Backend.Models.Brand", null)
                        .WithMany("VIN")
                        .HasForeignKey("BrandName");

                    b.HasOne("Backend.Models.CarColor", null)
                        .WithMany("VIN")
                        .HasForeignKey("CarColorColorName");

                    b.HasOne("Backend.Models.FuelType", null)
                        .WithMany("VIN")
                        .HasForeignKey("FuelTypeType");

                    b.HasOne("Backend.Models.VehicleEquipment", null)
                        .WithMany("VIN")
                        .HasForeignKey("VehicleEquipmentEquipment");
                });

            modelBuilder.Entity("Backend.Models.Brand", b =>
                {
                    b.Navigation("VIN");
                });

            modelBuilder.Entity("Backend.Models.CarColor", b =>
                {
                    b.Navigation("VIN");
                });

            modelBuilder.Entity("Backend.Models.FuelType", b =>
                {
                    b.Navigation("VIN");
                });

            modelBuilder.Entity("Backend.Models.VehicleEquipment", b =>
                {
                    b.Navigation("VIN");
                });
#pragma warning restore 612, 618
        }
    }
}
