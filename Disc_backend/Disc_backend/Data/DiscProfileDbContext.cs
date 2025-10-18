using System;
using System.Collections.Generic;
using Disc_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Disc_backend.Data;

public partial class DiscProfileDbContext : DbContext
{
    public DiscProfileDbContext()
    {
    }

    public DiscProfileDbContext(DbContextOptions<DiscProfileDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DiscProfile> DiscProfiles { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectsDiscProfile> ProjectsDiscProfiles { get; set; }

    public virtual DbSet<SocialEvent> SocialEvents { get; set; }

    public virtual DbSet<StressMeasure> StressMeasures { get; set; }

    public virtual DbSet<Models.Task> Tasks { get; set; }

    public virtual DbSet<TaskCompleteInterval> TaskCompleteIntervals { get; set; }

    public virtual DbSet<VwSocialEventsOverview> VwSocialEventsOverviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:defaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__companie__3213E83F4B1B42F8");

            entity.ToTable("companies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BusinessField)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("business_field");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83F546F342C");

            entity.ToTable("departments");

            entity.HasIndex(e => e.CompanyId, "idx_departments_company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Company).WithMany(p => p.Departments)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__departmen__compa__1F63A897");
        });

        modelBuilder.Entity<DiscProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__disc_pro__3213E83FAA760535");

            entity.ToTable("disc_profiles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__educatio__3213E83F8CF6A297");

            entity.ToTable("educations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F5D6B3187");

            entity.ToTable("employees");

            entity.HasIndex(e => e.CompanyId, "idx_employees_company");

            entity.HasIndex(e => e.DepartmentId, "idx_employees_department");

            entity.HasIndex(e => e.DiscProfileId, "idx_employees_disc_profile");

            entity.HasIndex(e => e.PersonId, "idx_employees_person");

            entity.HasIndex(e => e.PositionId, "idx_employees_position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DiscProfileId).HasColumnName("disc_profile_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Company).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__compa__318258D2");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__employees__depar__336AA144");

            entity.HasOne(d => d.DiscProfile).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DiscProfileId)
                .HasConstraintName("FK__employees__disc___3552E9B6");

            entity.HasOne(d => d.Person).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__perso__32767D0B");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__employees__posit__345EC57D");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__persons__3213E83F81E5EFAC");

            entity.ToTable("persons");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cpr)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cpr");
            entity.Property(e => e.Experience).HasColumnName("experience");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_path");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PrivateEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("private_email");
            entity.Property(e => e.PrivatePhone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("private_phone");

            entity.HasMany(d => d.Educations).WithMany(p => p.People)
                .UsingEntity<Dictionary<string, object>>(
                    "PersonsEducation",
                    r => r.HasOne<Education>().WithMany()
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__persons_e__educa__2CBDA3B5"),
                    l => l.HasOne<Person>().WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__persons_e__perso__2BC97F7C"),
                    j =>
                    {
                        j.HasKey("PersonId", "EducationId").HasName("PK__persons___306444219B3FD3AC");
                        j.ToTable("persons_educations");
                        j.HasIndex(new[] { "EducationId" }, "idx_persons_educations_educations");
                        j.HasIndex(new[] { "PersonId" }, "idx_persons_educations_persons");
                        j.IndexerProperty<int>("PersonId").HasColumnName("person_id");
                        j.IndexerProperty<int>("EducationId").HasColumnName("education_id");
                    });
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__position__3213E83F6276E9BA");

            entity.ToTable("positions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__projects__3213E83F0A8B9105");

            entity.ToTable("projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Completed).HasColumnName("completed");
            entity.Property(e => e.Deadline)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deadline");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NumberOfEmployees).HasColumnName("number_of_employees");

            entity.HasMany(d => d.Employees).WithMany(p => p.Projects)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeesProject",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__emplo__4C364F0E"),
                    l => l.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__proje__4B422AD5"),
                    j =>
                    {
                        j.HasKey("ProjectId", "EmployeeId").HasName("PK__employee__202B7EA5DD0CEBA1");
                        j.ToTable("employees_projects");
                        j.HasIndex(new[] { "EmployeeId" }, "idx_employees_projects_employees");
                        j.HasIndex(new[] { "ProjectId" }, "idx_employees_projects_projects");
                        j.IndexerProperty<int>("ProjectId").HasColumnName("project_id");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                    });
        });

        modelBuilder.Entity<ProjectsDiscProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__projects__3213E83FDC323E52");

            entity.ToTable("projects_disc_profiles");

            entity.HasIndex(e => e.DiscProfileId, "idx_project_disc_profile_disc_profile");

            entity.HasIndex(e => e.ProjectId, "idx_project_disc_profile_project");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiscProfileId).HasColumnName("disc_profile_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");

            entity.HasOne(d => d.DiscProfile).WithMany(p => p.ProjectsDiscProfiles)
                .HasForeignKey(d => d.DiscProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__projects___disc___5006DFF2");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectsDiscProfiles)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__projects___proje__4F12BBB9");
        });

        modelBuilder.Entity<SocialEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__social_e__3213E83FF10B03F7");

            entity.ToTable("social_events");

            entity.HasIndex(e => e.CompanyId, "idx_social_events_company");

            entity.HasIndex(e => e.DiscProfileId, "idx_social_events_disc_profile");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DiscProfileId).HasColumnName("disc_profile_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Company).WithMany(p => p.SocialEvents)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__social_ev__compa__251C81ED");

            entity.HasOne(d => d.DiscProfile).WithMany(p => p.SocialEvents)
                .HasForeignKey(d => d.DiscProfileId)
                .HasConstraintName("FK__social_ev__disc___24285DB4");

            entity.HasMany(d => d.Employees).WithMany(p => p.SocialEvents)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeesSocialEvent",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__emplo__4865BE2A"),
                    l => l.HasOne<SocialEvent>().WithMany()
                        .HasForeignKey("SocialEventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__socia__477199F1"),
                    j =>
                    {
                        j.HasKey("SocialEventId", "EmployeeId").HasName("PK__employee__EF36199AC0F43A67");
                        j.ToTable("employees_social_events");
                        j.HasIndex(new[] { "EmployeeId" }, "idx_employees_social_events_employees");
                        j.HasIndex(new[] { "SocialEventId" }, "idx_employees_social_events_social");
                        j.IndexerProperty<int>("SocialEventId").HasColumnName("social_event_id");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                    });
        });

        modelBuilder.Entity<StressMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__stress_m__3213E83F5D1F5605");

            entity.ToTable("stress_measures");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Measure).HasColumnName("measure");
            entity.Property(e => e.TaskId).HasColumnName("task_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.StressMeasures)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stress_me__emplo__3FD07829");

            entity.HasOne(d => d.Task).WithMany(p => p.StressMeasures)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stress_me__task___40C49C62");
        });

        modelBuilder.Entity<Models.Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tasks__3213E83F89491849");

            entity.ToTable("tasks", tb => tb.HasTrigger("task_is_complete"));

            entity.HasIndex(e => e.ProjectId, "idx_tasks_project");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Completed).HasColumnName("completed");
            entity.Property(e => e.Evaluation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("evaluation");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.TimeOfCompletion)
                .HasColumnType("datetime")
                .HasColumnName("time_of_completion");
            entity.Property(e => e.TimeToComplete).HasColumnName("time_to_complete");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tasks__project_i__3BFFE745");

            entity.HasOne(d => d.TimeToCompleteNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TimeToComplete)
                .HasConstraintName("FK__tasks__time_to_c__3CF40B7E");

            entity.HasMany(d => d.Employees).WithMany(p => p.Tasks)
                .UsingEntity<Dictionary<string, object>>(
                    "TasksEmployee",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tasks_emp__emplo__44952D46"),
                    l => l.HasOne<Models.Task>().WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tasks_emp__task___43A1090D"),
                    j =>
                    {
                        j.HasKey("TaskId", "EmployeeId").HasName("PK__tasks_em__98C0F43723EB29C6");
                        j.ToTable("tasks_employees");
                        j.HasIndex(new[] { "EmployeeId" }, "idx_tasks_employees_employees");
                        j.HasIndex(new[] { "TaskId" }, "idx_tasks_employees_tasks");
                        j.IndexerProperty<int>("TaskId").HasColumnName("task_id");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                    });
        });

        modelBuilder.Entity<TaskCompleteInterval>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__task_com__3213E83FD13E17FA");

            entity.ToTable("task_complete_intervals");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TimeToComplete)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("time_to_complete");
        });

        modelBuilder.Entity<VwSocialEventsOverview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SocialEventsOverview");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.DiscColor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("disc_color");
            entity.Property(e => e.DiscDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("disc_description");
            entity.Property(e => e.DiscProfileName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("disc_profile_name");
            entity.Property(e => e.EventDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("event_description");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("event_name");
            entity.Property(e => e.SocialEventId).HasColumnName("social_event_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
