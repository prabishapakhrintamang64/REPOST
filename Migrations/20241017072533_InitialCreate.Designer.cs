﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace Datas.Migrations
{
    [DbContext(typeof(EmployysContext))]
    [Migration("20241017072533_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Models.Employys", b =>
                {
                    b.Property<int>("EmployyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmployyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmployyId");

                    b.ToTable("Employys");
                });

            modelBuilder.Entity("Models.EmployysLeave", b =>
                {
                    b.Property<int>("LeaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumOfDays")
                        .HasColumnType("INTEGER");

                    b.HasKey("LeaveId");

                    b.ToTable("EmployysLeave");
                });
#pragma warning restore 612, 618
        }
    }
}
