﻿// <auto-generated />
using System;
using DesarrolloTec.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesarrolloTec.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("ProjectsId")
                        .HasColumnType("int");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("specialization")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectsId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.EmployeeProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CustomersId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.ProjectService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProjectsId")
                        .HasColumnType("int");

                    b.Property<int?>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectsId");

                    b.HasIndex("ServicesId");

                    b.ToTable("ProjectService");
                });

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("EstimatedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.Employee", b =>
                {
                    b.HasOne("DesarrolloTec.Shered.Entities.Project", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectsId");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.EmployeeProject", b =>
                {
                    b.HasOne("DesarrolloTec.Shered.Entities.Employee", "Employees")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeesId");

                    b.HasOne("DesarrolloTec.Shered.Entities.Project", "Projects")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectsId");

                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.Project", b =>
                {
                    b.HasOne("DesarrolloTec.Shered.Entities.Customer", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomersId");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.ProjectService", b =>
                {
                    b.HasOne("DesarrolloTec.Shered.Entities.Project", "Projects")
                        .WithMany("ProjectServices")
                        .HasForeignKey("ProjectsId");

                    b.HasOne("DesarrolloTec.Shered.Entities.Service", "Services")
                        .WithMany()
                        .HasForeignKey("ServicesId");

                    b.Navigation("Projects");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeProjects");
                });

            modelBuilder.Entity("DesarrolloTec.Shered.Entities.Project", b =>
                {
                    b.Navigation("EmployeeProjects");

                    b.Navigation("ProjectServices");
                });
#pragma warning restore 612, 618
        }
    }
}
