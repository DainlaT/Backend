using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Backend.DB.Models;

namespace Backend.DB.Data;

public partial class KnowledgeDbContext : DbContext
{
    public KnowledgeDbContext()
    {
    }

    public KnowledgeDbContext(DbContextOptions<KnowledgeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Discipline> Disciplines { get; set; }

    public virtual DbSet<DisciplineTeacher> DisciplineTeachers { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StudyGroup> StudyGroups { get; set; }

    public virtual DbSet<StudyProgram> StudyPrograms { get; set; }

    public virtual DbSet<Testing> Testings { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83FFB9E7FCC");

            entity.ToTable("departments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FacultyId).HasColumnName("faculty_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Faculty).WithMany(p => p.Departments)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__departmen__facul__5DCAEF64");
        });

        modelBuilder.Entity<Discipline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__discipli__3213E83F3A8C89D4");

            entity.ToTable("disciplines");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Department).WithMany(p => p.Disciplines)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__disciplin__depar__66603565");
        });

        modelBuilder.Entity<DisciplineTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__discipli__3213E83F12EC2320");

            entity.ToTable("discipline_teacher");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DisciplineId).HasColumnName("discipline_id");
            entity.Property(e => e.ResponsibleTeacherId).HasColumnName("responsible_teacher_id");

            entity.HasOne(d => d.Discipline).WithMany(p => p.DisciplineTeachers)
                .HasForeignKey(d => d.DisciplineId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__disciplin__disci__797309D9");

            entity.HasOne(d => d.ResponsibleTeacher).WithMany(p => p.DisciplineTeachers)
                .HasForeignKey(d => d.ResponsibleTeacherId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__disciplin__respo__7A672E12");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__facultie__3213E83FBE3BA22C");

            entity.ToTable("faculties");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FacultyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("faculty_name");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reports__3213E83FF39C3E5E");

            entity.ToTable("reports");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AllDone).HasColumnName("all_done");
            entity.Property(e => e.DisciplineId).HasColumnName("discipline_id");
            entity.Property(e => e.DoneInElectronicForm).HasColumnName("done_in_electronic_form");
            entity.Property(e => e.DoneInPaperForm).HasColumnName("done_in_paper_form");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_path");
            entity.Property(e => e.IsCorrect).HasColumnName("is_correct");
            entity.Property(e => e.ResultOfAttestation)
                .HasColumnType("text")
                .HasColumnName("result_of_attestation");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Discipline).WithMany(p => p.Reports)
                .HasForeignKey(d => d.DisciplineId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__reports__discipl__693CA210");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Reports)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__reports__teacher__6A30C649");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F52C644FD");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__statuses__3213E83FA5731117");

            entity.ToTable("statuses");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<StudyGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__study_gr__3213E83F1205F8C9");

            entity.ToTable("study_groups");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.GroupNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("group_number");
            entity.Property(e => e.StudyProgramId).HasColumnName("study_program_id");

            entity.HasOne(d => d.StudyProgram).WithMany(p => p.StudyGroups)
                .HasForeignKey(d => d.StudyProgramId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__study_gro__study__6383C8BA");
        });

        modelBuilder.Entity<StudyProgram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__study_pr__3213E83FF4D1F0A8");

            entity.ToTable("study_programs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CypherOfTheDirection)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cypher_of_the_direction");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Department).WithMany(p => p.StudyPrograms)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__study_pro__depar__60A75C0F");
        });

        modelBuilder.Entity<Testing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__testing__3213E83FEC9AF393");

            entity.ToTable("testing");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DisciplineId).HasColumnName("discipline_id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.ResultOfTesting)
                .HasColumnType("text")
                .HasColumnName("result_of_testing");
            entity.Property(e => e.ScheduledDate).HasColumnName("scheduled_date");
            entity.Property(e => e.ScheduledTime).HasColumnName("scheduled_time");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Discipline).WithMany(p => p.Testings)
                .HasForeignKey(d => d.DisciplineId)
                .HasConstraintName("FK__testing__discipl__75A278F5");

            entity.HasOne(d => d.Group).WithMany(p => p.Testings)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__testing__group_i__74AE54BC");

            entity.HasOne(d => d.Report).WithMany(p => p.Testings)
                .HasForeignKey(d => d.ReportId)
                .HasConstraintName("FK__testing__report___76969D2E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F341FD6DD");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164A645B7AF").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FacultyId).HasColumnName("faculty_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Faculty).WithMany(p => p.Users)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__users__faculty_i__5AEE82B9");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__users__role_id__59063A47");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__users__status_id__59FA5E80");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
