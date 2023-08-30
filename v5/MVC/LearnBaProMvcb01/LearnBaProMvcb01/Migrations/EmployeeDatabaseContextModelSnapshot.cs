﻿// <auto-generated />
using System;
using LearnBaProMvcb01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LearnBaProMvcb01.Migrations
{
    [DbContext(typeof(EmployeeDatabaseContext))]
    partial class EmployeeDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LearnBaProMvcb01.Models.Department", b =>
                {
                    b.Property<int>("IdDept")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameDept")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IdDept");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("LearnBaProMvcb01.Models.Employee", b =>
                {
                    b.Property<int>("IdEmp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentIdDept")
                        .HasColumnType("int");

                    b.Property<string>("EnrollDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDept")
                        .HasColumnType("int");

                    b.Property<string>("NameEmp")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IdEmp");

                    b.HasIndex("DepartmentIdDept");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("LearnBaProMvcb01.Models.Employee", b =>
                {
                    b.HasOne("LearnBaProMvcb01.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentIdDept");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("LearnBaProMvcb01.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
