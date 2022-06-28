﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apipackages.Data;

#nullable disable

namespace apipackages.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220605204101_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("apipackages.Models.DetailPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodePackage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployesId")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<double>("PrecioPackage")
                        .HasColumnType("float");

                    b.Property<string>("TypePackage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployesId");

                    b.HasIndex("PackageId");

                    b.ToTable("DetailPackages");
                });

            modelBuilder.Entity("apipackages.Models.Employes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employes", (string)null);
                });

            modelBuilder.Entity("apipackages.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DestinoPaquete")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstadoEntrega")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEnvio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRuta")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<double>("IvaPaquete")
                        .HasColumnType("float");

                    b.Property<string>("OrigenPaquete")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SubtotalPaquete")
                        .HasColumnType("float");

                    b.Property<double>("TotalPaquete")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("apipackages.Models.DetailPackage", b =>
                {
                    b.HasOne("apipackages.Models.Employes", "Employes")
                        .WithMany("detailPackages")
                        .HasForeignKey("EmployesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apipackages.Models.Package", "Package")
                        .WithMany("detailPackages")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employes");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("apipackages.Models.Employes", b =>
                {
                    b.Navigation("detailPackages");
                });

            modelBuilder.Entity("apipackages.Models.Package", b =>
                {
                    b.Navigation("detailPackages");
                });
#pragma warning restore 612, 618
        }
    }
}
