﻿// <auto-generated />
using System;
using Angular.Model.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Angular.Model.Migrations
{
    [DbContext(typeof(AngularAPIContext))]
    [Migration("20210909035929_AspNetDatabase")]
    partial class AspNetDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Angular.Model.DTOs.TblAttendances", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Absent")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<bool?>("Present")
                        .HasColumnType("bit");

                    b.Property<bool?>("Reason")
                        .HasColumnType("bit");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Tbl_Attendances");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblClasses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassCode")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Tbl_Classes");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblDepartments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("DepartmentCode")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Departments");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblSchedules", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Tbl_Schedules");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblSections", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfSession")
                        .HasColumnType("int");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("SectionCode")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("SectionName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Tbl_Sections");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblStudentSubject", b =>
                {
                    b.Property<int>("StudentSubjectCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("StudentSubjectCode");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Tbl_StudentSubject");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblStudents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("StudentCode")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("StudentEmail")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("StudentGender")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("StudentImage")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("StudentPhone")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Tbl_Students");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblSubjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("NumberOfPeriod")
                        .HasColumnType("int");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("SubjectCode")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tbl_Subjects");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblTeachers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("TeacherCode")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("TeacherEmail")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("TeacherGender")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("TeacherImage")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("TeacherName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("TeacherPhone")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Tbl_Teachers");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblAttendances", b =>
                {
                    b.HasOne("Angular.Model.DTOs.TblStudents", "Student")
                        .WithMany("TblAttendances")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_Tbl_Attendances_Tbl_Students");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblClasses", b =>
                {
                    b.HasOne("Angular.Model.DTOs.TblDepartments", "Department")
                        .WithMany("TblClasses")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Tbl_Classes_Tbl_Departments");

                    b.HasOne("Angular.Model.DTOs.TblTeachers", "Teacher")
                        .WithMany("TblClasses")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("FK_Tbl_Classes_Tbl_Teachers");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblSchedules", b =>
                {
                    b.HasOne("Angular.Model.DTOs.TblClasses", "Class")
                        .WithMany("TblSchedules")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK_Tbl_Schedules_Tbl_Classes");

                    b.HasOne("Angular.Model.DTOs.TblSubjects", "Subject")
                        .WithMany("TblSchedules")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_Tbl_Schedules_Tbl_Subjects");

                    b.HasOne("Angular.Model.DTOs.TblTeachers", "Teacher")
                        .WithMany("TblSchedules")
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("FK_Tbl_Schedules_Tbl_Teachers");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblSections", b =>
                {
                    b.HasOne("Angular.Model.DTOs.TblDepartments", "Department")
                        .WithMany("TblSections")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Tbl_Sections_Tbl_Departments");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblStudentSubject", b =>
                {
                    b.HasOne("Angular.Model.DTOs.TblStudents", "Students")
                        .WithMany("TblStudentSubject")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_Tbl_Students_Tbl_StudentSubject");

                    b.HasOne("Angular.Model.DTOs.TblSubjects", "Subjects")
                        .WithMany("TblStudentSubject")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_Tbl_Subjects_Tbl_StudentSubject");
                });

            modelBuilder.Entity("Angular.Model.DTOs.TblStudents", b =>
                {
                    b.HasOne("Angular.Model.DTOs.TblClasses", "Class")
                        .WithMany("TblStudents")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK_Tbl_Students_Tbl_Classes");
                });
#pragma warning restore 612, 618
        }
    }
}
