﻿// <auto-generated />
using System;
using FitKitApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitKitApp.Migrations
{
    [DbContext(typeof(FitKitAppContext))]
    [Migration("20200728123711_InicijalnaFitKit1")]
    partial class InicijalnaFitKit1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitKitApp.Models.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EducationLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<float>("Plata")
                        .HasColumnType("real");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Profilna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Tezina")
                        .HasColumnType("real");

                    b.Property<float>("Visina")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Coach");
                });

            modelBuilder.Entity("FitKitApp.Models.Objekt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Coach1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Coach2Id")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kvadratura")
                        .HasColumnType("int");

                    b.Property<string>("Lokacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxClients")
                        .HasColumnType("int");

                    b.Property<string>("OtvorZatvor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipVezbanje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Coach1Id");

                    b.HasIndex("Coach2Id");

                    b.ToTable("Objekt");
                });

            modelBuilder.Entity("FitKitApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("ObemBiceps")
                        .HasColumnType("int");

                    b.Property<int>("ObemDesenBiceps")
                        .HasColumnType("int");

                    b.Property<int>("ObemDesenBut")
                        .HasColumnType("int");

                    b.Property<int>("ObemGradi")
                        .HasColumnType("int");

                    b.Property<int>("ObemLevBut")
                        .HasColumnType("int");

                    b.Property<int>("ObemStruk")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("ProfilePic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Tezina")
                        .HasColumnType("real");

                    b.Property<int>("Visina")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FitKitApp.Models.Zaclenuvanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ObjektId")
                        .HasColumnType("int");

                    b.Property<string>("OdobrenNeodobren")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Termin")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ObjektId");

                    b.HasIndex("UserId");

                    b.ToTable("Zaclenuvanje");
                });

            modelBuilder.Entity("FitKitApp.Models.Objekt", b =>
                {
                    b.HasOne("FitKitApp.Models.Coach", "Coach1")
                        .WithMany("Objekti1")
                        .HasForeignKey("Coach1Id");

                    b.HasOne("FitKitApp.Models.Coach", "Coach2")
                        .WithMany("Objekti2")
                        .HasForeignKey("Coach2Id");
                });

            modelBuilder.Entity("FitKitApp.Models.Zaclenuvanje", b =>
                {
                    b.HasOne("FitKitApp.Models.Objekt", "Objekt")
                        .WithMany("Korisnici")
                        .HasForeignKey("ObjektId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitKitApp.Models.User", "User")
                        .WithMany("Objekti")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
