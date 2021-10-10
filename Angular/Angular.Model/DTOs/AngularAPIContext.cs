using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Angular.Model.DTOs
{
    public partial class AngularAPIContext : DbContext
    {
        public AngularAPIContext()
        {
        }

        public AngularAPIContext(DbContextOptions<AngularAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblStudentSubject> TblStudentSubjects { get; set; }
        public virtual DbSet<TblAttendances> TblAttendances { get; set; }
        public virtual DbSet<TblClasses> TblClasses { get; set; }
        public virtual DbSet<TblDepartments> TblDepartments { get; set; }
        public virtual DbSet<TblSchedules> TblSchedules { get; set; }
        public virtual DbSet<TblSections> TblSections { get; set; }
        public virtual DbSet<TblStudents> TblStudents { get; set; }
        public virtual DbSet<TblSubjects> TblSubjects { get; set; }
        public virtual DbSet<TblTeachers> TblTeachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-V9M8DS1;Database=AngularAPI;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblStudentSubject>(entity =>
            {
                entity.ToTable("Tbl_StudentSubject");

                entity.HasKey(e => e.StudentSubjectCode);

                entity.HasOne(d => d.Subjects)
                    .WithMany(p => p.TblStudentSubject)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Subjects_Tbl_StudentSubject");

                entity.HasOne(d => d.Students)
                    .WithMany(p => p.TblStudentSubject)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Students_Tbl_StudentSubject");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblAttendances>(entity =>
            {
                entity.ToTable("Tbl_Attendances");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TblAttendances)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Tbl_Attendances_Tbl_Students");
            });

            modelBuilder.Entity<TblClasses>(entity =>
            {
                entity.ToTable("Tbl_Classes");

                entity.Property(e => e.ClassCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblClasses)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Tbl_Classes_Tbl_Departments");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TblClasses)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Tbl_Classes_Tbl_Teachers");
            });

            modelBuilder.Entity<TblDepartments>(entity =>
            {
                entity.ToTable("Tbl_Departments");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSchedules>(entity =>
            {
                entity.ToTable("Tbl_Schedules");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TblSchedules)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Tbl_Schedules_Tbl_Classes");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TblSchedules)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Tbl_Schedules_Tbl_Subjects");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TblSchedules)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Tbl_Schedules_Tbl_Teachers");
            });

            modelBuilder.Entity<TblSections>(entity =>
            {
                entity.ToTable("Tbl_Sections");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SectionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SectionName).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblSections)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Tbl_Sections_Tbl_Departments");
            });

            modelBuilder.Entity<TblStudents>(entity =>
            {
                entity.ToTable("Tbl_Students");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StudentCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentGender).HasMaxLength(50);

                entity.Property(e => e.StudentImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName).HasMaxLength(50);

                entity.Property(e => e.StudentPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TblStudents)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Tbl_Students_Tbl_Classes");
            });

            modelBuilder.Entity<TblSubjects>(entity =>
            {
                entity.ToTable("Tbl_Subjects");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SubjectCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblTeachers>(entity =>
            {
                entity.ToTable("Tbl_Teachers");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TeacherCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherGender).HasMaxLength(50);

                entity.Property(e => e.TeacherImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherName).HasMaxLength(50);

                entity.Property(e => e.TeacherPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
