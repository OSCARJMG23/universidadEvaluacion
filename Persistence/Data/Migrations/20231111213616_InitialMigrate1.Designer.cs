﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(ApiUniversidadContext))]
    [Migration("20231111213616_InitialMigrate1")]
    partial class InitialMigrate1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.AlumnoSeMatriculaAsignatura", b =>
                {
                    b.Property<int>("IdAsignaturaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdAlumnoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdCursoFk")
                        .HasColumnType("int");

                    b.HasKey("IdAsignaturaFk", "IdAlumnoFk", "IdCursoFk");

                    b.HasIndex("IdAlumnoFk");

                    b.HasIndex("IdCursoFk");

                    b.ToTable("AlumnoSeMatriculaAsignatura", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Creditos")
                        .HasColumnType("float");

                    b.Property<int>("Cuatrimestre")
                        .HasColumnType("int");

                    b.Property<int>("Curso")
                        .HasColumnType("int");

                    b.Property<int>("IdGradoFk")
                        .HasColumnType("int");

                    b.Property<int?>("IdProfesorFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("IdGradoFk");

                    b.HasIndex("IdProfesorFk");

                    b.ToTable("asignatura", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CursoEscolar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<short>("Fin")
                        .HasColumnType("YEAR(4)");

                    b.Property<short>("Inicio")
                        .HasColumnType("YEAR(4)");

                    b.HasKey("Id");

                    b.ToTable("cursoescolar", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("departamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Grado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("grado", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("persona", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamentoFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamentoFk");

                    b.ToTable("profesor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AlumnoSeMatriculaAsignatura", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "Alumno")
                        .WithMany("AlumnoSeMatriculaAsignaturas")
                        .HasForeignKey("IdAlumnoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Asignatura", "Asignatura")
                        .WithMany("AlumnoSeMatriculaAsignaturas")
                        .HasForeignKey("IdAsignaturaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CursoEscolar", "CursoEscolar")
                        .WithMany("AlumnoSeMatriculaAsignaturas")
                        .HasForeignKey("IdCursoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Asignatura");

                    b.Navigation("CursoEscolar");
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.HasOne("Domain.Entities.Grado", "Grado")
                        .WithMany("Asignaturas")
                        .HasForeignKey("IdGradoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Profesor", "Profesor")
                        .WithMany("Asignaturas")
                        .HasForeignKey("IdProfesorFk");

                    b.Navigation("Grado");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "Persona")
                        .WithMany("Profesores")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Departamento", "Departamento")
                        .WithMany("Profesores")
                        .HasForeignKey("IdDepartamentoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.Navigation("AlumnoSeMatriculaAsignaturas");
                });

            modelBuilder.Entity("Domain.Entities.CursoEscolar", b =>
                {
                    b.Navigation("AlumnoSeMatriculaAsignaturas");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("Domain.Entities.Grado", b =>
                {
                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Navigation("AlumnoSeMatriculaAsignaturas");

                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.Navigation("Asignaturas");
                });
#pragma warning restore 612, 618
        }
    }
}
