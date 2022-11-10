﻿// <auto-generated />
using ApiELection.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiELection.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20221105011802_InitCreate")]
    partial class InitCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiELection.models.Bureau", b =>
                {
                    b.Property<int>("NumB")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumB"), 1L, 1);

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.Property<int>("CentreNumC")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NumB");

                    b.HasIndex("CentreNumC");

                    b.ToTable("Bureau");
                });

            modelBuilder.Entity("ApiELection.models.Centre", b =>
                {
                    b.Property<int>("NumC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumC"), 1L, 1);

                    b.Property<string>("Lieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreBureau")
                        .HasColumnType("int");

                    b.HasKey("NumC");

                    b.ToTable("Centre");
                });

            modelBuilder.Entity("ApiELection.models.Electeur", b =>
                {
                    b.Property<int>("NumE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumE"), 1L, 1);

                    b.Property<int>("BureauNumB")
                        .HasColumnType("int");

                    b.Property<string>("Lieu_residence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NumE");

                    b.HasIndex("BureauNumB");

                    b.ToTable("Electeur");
                });

            modelBuilder.Entity("ApiELection.models.Bureau", b =>
                {
                    b.HasOne("ApiELection.models.Centre", "Centre")
                        .WithMany("Bureaux")
                        .HasForeignKey("CentreNumC")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Centre");
                });

            modelBuilder.Entity("ApiELection.models.Electeur", b =>
                {
                    b.HasOne("ApiELection.models.Bureau", "Bureau")
                        .WithMany("Electeurs")
                        .HasForeignKey("BureauNumB")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bureau");
                });

            modelBuilder.Entity("ApiELection.models.Bureau", b =>
                {
                    b.Navigation("Electeurs");
                });

            modelBuilder.Entity("ApiELection.models.Centre", b =>
                {
                    b.Navigation("Bureaux");
                });
#pragma warning restore 612, 618
        }
    }
}
