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

    public virtual DbSet<EmployeesPrivateDatum> EmployeesPrivateData { get; set; }

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
            entity.HasKey(e => e.Id).HasName("PK__companie__3213E83F50CD4DC0");

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
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83FA094C743");

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
                .HasConstraintName("FK__departmen__compa__2C88998B");
        });

        modelBuilder.Entity<DiscProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__disc_pro__3213E83F029CF1C1");

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
            entity.HasKey(e => e.Id).HasName("PK__educatio__3213E83F36DF0BD7");

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
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F44BB2E5A");

            entity.ToTable("employees");

            entity.HasIndex(e => e.CompanyId, "idx_employees_company");

            entity.HasIndex(e => e.DepartmentId, "idx_employees_department");

            entity.HasIndex(e => e.DiscProfileId, "idx_employees_disc_profile");

            entity.HasIndex(e => e.PositionId, "idx_employees_position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DiscProfileId).HasColumnName("disc_profile_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
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
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Company).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__compa__38EE7070");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__employees__depar__39E294A9");

            entity.HasOne(d => d.DiscProfile).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DiscProfileId)
                .HasConstraintName("FK__employees__disc___3BCADD1B");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__employees__posit__3AD6B8E2");

            entity.HasMany(d => d.Educations).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeesEducation",
                    r => r.HasOne<Education>().WithMany()
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__educa__4277DAAA"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__emplo__4183B671"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "EducationId").HasName("PK__employee__A1720756FC58ED45");
                        j.ToTable("employees_educations");
                        j.HasIndex(new[] { "EducationId" }, "idx_employees_educations_educations");
                        j.HasIndex(new[] { "EmployeeId" }, "idx_employees_educations_employees");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                        j.IndexerProperty<int>("EducationId").HasColumnName("education_id");
                    });
        });

        modelBuilder.Entity<EmployeesPrivateDatum>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__employee__C52E0BA8191D9F7B");

            entity.ToTable("employees_private_data");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.Cpr)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cpr");
            entity.Property(e => e.PrivateEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("private_email");
            entity.Property(e => e.PrivatePhone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("private_phone");

            entity.HasOne(d => d.Employee).WithOne(p => p.EmployeesPrivateDatum)
                .HasForeignKey<EmployeesPrivateDatum>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__emplo__3EA749C6");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__position__3213E83F551747E8");

            entity.ToTable("positions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__projects__3213E83F1B18E29B");

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
                        .HasConstraintName("FK__employees__emplo__595B4002"),
                    l => l.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__proje__58671BC9"),
                    j =>
                    {
                        j.HasKey("ProjectId", "EmployeeId").HasName("PK__employee__202B7EA514A1B524");
                        j.ToTable("employees_projects");
                        j.HasIndex(new[] { "EmployeeId" }, "idx_employees_projects_employees");
                        j.HasIndex(new[] { "ProjectId" }, "idx_employees_projects_projects");
                        j.IndexerProperty<int>("ProjectId").HasColumnName("project_id");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                    });
        });

        modelBuilder.Entity<ProjectsDiscProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__projects__3213E83F505ABC7D");

            entity.ToTable("projects_disc_profiles");

            entity.HasIndex(e => e.DiscProfileId, "idx_project_disc_profile_disc_profile");

            entity.HasIndex(e => e.ProjectId, "idx_project_disc_profile_project");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiscProfileId).HasColumnName("disc_profile_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");

            entity.HasOne(d => d.DiscProfile).WithMany(p => p.ProjectsDiscProfiles)
                .HasForeignKey(d => d.DiscProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__projects___disc___5D2BD0E6");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectsDiscProfiles)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__projects___proje__5C37ACAD");
        });

        modelBuilder.Entity<SocialEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__social_e__3213E83FC21C6CCE");

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
                .HasConstraintName("FK__social_ev__compa__324172E1");

            entity.HasOne(d => d.DiscProfile).WithMany(p => p.SocialEvents)
                .HasForeignKey(d => d.DiscProfileId)
                .HasConstraintName("FK__social_ev__disc___314D4EA8");

            entity.HasMany(d => d.Employees).WithMany(p => p.SocialEvents)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeesSocialEvent",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__emplo__558AAF1E"),
                    l => l.HasOne<SocialEvent>().WithMany()
                        .HasForeignKey("SocialEventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__socia__54968AE5"),
                    j =>
                    {
                        j.HasKey("SocialEventId", "EmployeeId").HasName("PK__employee__EF36199A93E4C34B");
                        j.ToTable("employees_social_events");
                        j.HasIndex(new[] { "EmployeeId" }, "idx_employees_social_events_employees");
                        j.HasIndex(new[] { "SocialEventId" }, "idx_employees_social_events_social");
                        j.IndexerProperty<int>("SocialEventId").HasColumnName("social_event_id");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                    });
        });

        modelBuilder.Entity<StressMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__stress_m__3213E83FCCAFDD4D");

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
                .HasConstraintName("FK__stress_me__emplo__4CF5691D");

            entity.HasOne(d => d.Task).WithMany(p => p.StressMeasures)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stress_me__task___4DE98D56");
        });

        modelBuilder.Entity<Models.Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tasks__3213E83FAA372DEF");

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
                .HasConstraintName("FK__tasks__project_i__4924D839");

            entity.HasOne(d => d.TimeToCompleteNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TimeToComplete)
                .HasConstraintName("FK__tasks__time_to_c__4A18FC72");

            entity.HasMany(d => d.Employees).WithMany(p => p.Tasks)
                .UsingEntity<Dictionary<string, object>>(
                    "TasksEmployee",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tasks_emp__emplo__51BA1E3A"),
                    l => l.HasOne<Models.Task>().WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tasks_emp__task___50C5FA01"),
                    j =>
                    {
                        j.HasKey("TaskId", "EmployeeId").HasName("PK__tasks_em__98C0F437B4FC9EE2");
                        j.ToTable("tasks_employees");
                        j.HasIndex(new[] { "EmployeeId" }, "idx_tasks_employees_employees");
                        j.HasIndex(new[] { "TaskId" }, "idx_tasks_employees_tasks");
                        j.IndexerProperty<int>("TaskId").HasColumnName("task_id");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                    });
        });

        modelBuilder.Entity<TaskCompleteInterval>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__task_com__3213E83F7302A065");

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
