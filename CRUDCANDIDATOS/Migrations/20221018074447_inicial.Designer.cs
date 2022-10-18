﻿// <auto-generated />
using System;
using CRUDCANDIDATOS.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUDCANDIDATOS.Migrations
{
    [DbContext(typeof(CandidatosDbContext))]
    [Migration("20221018074447_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CRUDCANDIDATOS.Models.CadidateExperiences", b =>
                {
                    b.Property<int>("IDCandidateExperience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDCandidateExperience"), 1L, 1);

                    b.Property<DateTime?>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IDCandidate1")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Salary")
                        .HasColumnType("float");

                    b.HasKey("IDCandidateExperience");

                    b.HasIndex("IDCandidate1");

                    b.ToTable("CadidateExperience");
                });

            modelBuilder.Entity("CRUDCANDIDATOS.Models.Candidate", b =>
                {
                    b.Property<int>("IDCandidate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDCandidate"), 1L, 1);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InserDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDCandidate");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("CRUDCANDIDATOS.Models.CadidateExperiences", b =>
                {
                    b.HasOne("CRUDCANDIDATOS.Models.Candidate", "IDCandidate")
                        .WithMany("Experience")
                        .HasForeignKey("IDCandidate1");

                    b.Navigation("IDCandidate");
                });

            modelBuilder.Entity("CRUDCANDIDATOS.Models.Candidate", b =>
                {
                    b.Navigation("Experience");
                });
#pragma warning restore 612, 618
        }
    }
}
