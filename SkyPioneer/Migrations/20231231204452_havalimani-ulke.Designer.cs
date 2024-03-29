﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkyPioneer.Models;

#nullable disable

namespace SkyPioneer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231231204452_havalimani-ulke")]
    partial class havalimaniulke
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SkyPioneer.Models.HavaAlani", b =>
                {
                    b.Property<int>("HavaAlaniID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HavaAlaniID"), 1L, 1);

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulke")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HavaAlaniID");

                    b.ToTable("HavaAlanlari");
                });

            modelBuilder.Entity("SkyPioneer.Models.HavaYolu", b =>
                {
                    b.Property<int>("HavaYoluID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HavaYoluID"), 1L, 1);

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulke")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HavaYoluID");

                    b.ToTable("HavaYollari");
                });

            modelBuilder.Entity("SkyPioneer.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciID"), 1L, 1);

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("MailAdres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoyIsim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yetki")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KullaniciID");

                    b.ToTable("Kullancilar");
                });

            modelBuilder.Entity("SkyPioneer.Models.Ucak", b =>
                {
                    b.Property<int>("UcakID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UcakID"), 1L, 1);

                    b.Property<int>("HavaYoluID")
                        .HasColumnType("int");

                    b.Property<int>("Kapasite")
                        .HasColumnType("int");

                    b.Property<string>("Modell")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UcakID");

                    b.HasIndex("HavaYoluID");

                    b.ToTable("Ucaklar");
                });

            modelBuilder.Entity("SkyPioneer.Models.Ucus", b =>
                {
                    b.Property<int>("UcusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UcusID"), 1L, 1);

                    b.Property<int>("Fiyat")
                        .HasColumnType("int");

                    b.Property<int>("KalkisHavaAlaniID")
                        .HasColumnType("int");

                    b.Property<DateTime>("KalkisSaati")
                        .HasColumnType("datetime2");

                    b.Property<int>("UcakID")
                        .HasColumnType("int");

                    b.Property<int>("VarisHavaAlaniID")
                        .HasColumnType("int");

                    b.HasKey("UcusID");

                    b.HasIndex("KalkisHavaAlaniID");

                    b.HasIndex("UcakID");

                    b.HasIndex("VarisHavaAlaniID");

                    b.ToTable("Ucuslar");
                });

            modelBuilder.Entity("SkyPioneer.Models.Ucak", b =>
                {
                    b.HasOne("SkyPioneer.Models.HavaYolu", "HavaYolu")
                        .WithMany("Ucaklar")
                        .HasForeignKey("HavaYoluID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HavaYolu");
                });

            modelBuilder.Entity("SkyPioneer.Models.Ucus", b =>
                {
                    b.HasOne("SkyPioneer.Models.HavaAlani", "Kalkis")
                        .WithMany()
                        .HasForeignKey("KalkisHavaAlaniID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkyPioneer.Models.Ucak", "Ucak")
                        .WithMany()
                        .HasForeignKey("UcakID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkyPioneer.Models.HavaAlani", "Varis")
                        .WithMany()
                        .HasForeignKey("VarisHavaAlaniID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kalkis");

                    b.Navigation("Ucak");

                    b.Navigation("Varis");
                });

            modelBuilder.Entity("SkyPioneer.Models.HavaYolu", b =>
                {
                    b.Navigation("Ucaklar");
                });
#pragma warning restore 612, 618
        }
    }
}
