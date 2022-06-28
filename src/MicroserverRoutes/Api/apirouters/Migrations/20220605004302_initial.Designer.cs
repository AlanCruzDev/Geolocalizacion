﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apirouters.Data;

#nullable disable

namespace apirouters.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220605004302_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("apirouters.Models.Coordinates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("LatDestination")
                        .HasColumnType("float");

                    b.Property<double>("LatOrigen")
                        .HasColumnType("float");

                    b.Property<double>("LogDestination")
                        .HasColumnType("float");

                    b.Property<double>("LogOrigen")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("apirouters.Models.Routes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("coordinatesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("coordinatesId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("apirouters.Models.Routes", b =>
                {
                    b.HasOne("apirouters.Models.Coordinates", "coordinates")
                        .WithMany("Routes")
                        .HasForeignKey("coordinatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("coordinates");
                });

            modelBuilder.Entity("apirouters.Models.Coordinates", b =>
                {
                    b.Navigation("Routes");
                });
#pragma warning restore 612, 618
        }
    }
}