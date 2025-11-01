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

    public virtual DbSet<EmployeesCredential> EmployeesCredentials { get; set; }

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
            entity.HasKey(e => e.Id).HasName("PK__companie__3213E83F8F60D46C");

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
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83F12CFBBFB");

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
                .HasConstraintName("FK__departmen__compa__6F4A8121");
        });

        modelBuilder.Entity<DiscProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__disc_pro__3213E83F5CF03D48");

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
            entity.HasKey(e => e.Id).HasName("PK__educatio__3213E83F59477180");

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
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F6FEE16AB");

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
                .HasConstraintName("FK__employees__compa__7BB05806");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__employees__depar__7CA47C3F");

            entity.HasOne(d => d.DiscProfile).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DiscProfileId)
                .HasConstraintName("FK__employees__disc___7E8CC4B1");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__employees__posit__7D98A078");

            entity.HasMany(d => d.Educations).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeesEducation",
                    r => r.HasOne<Education>().WithMany()
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__educa__08162EEB"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__emplo__07220AB2"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "EducationId").HasName("PK__employee__A17207563015EDD7");
                        j.ToTable("employees_educations");
                        j.HasIndex(new[] { "EducationId" }, "idx_employees_educations_educations");
                        j.HasIndex(new[] { "EmployeeId" }, "idx_employees_educations_employees");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                        j.IndexerProperty<int>("EducationId").HasColumnName("education_id");
                    });
        });

        modelBuilder.Entity<EmployeesCredential>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__employee__C52E0BA80241E284");

            entity.ToTable("employees_credentials");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.RequiresReset).HasColumnName("requires_reset");

            entity.HasOne(d => d.Employee).WithOne(p => p.EmployeesCredential)
                .HasForeignKey<EmployeesCredential>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__emplo__04459E07");
        });

        modelBuilder.Entity<EmployeesPrivateDatum>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__employee__C52E0BA8E348F7A3");

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
                .HasConstraintName("FK__employees__emplo__0169315C");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__position__3213E83FF6235F67");

            entity.ToTable("positions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__projects__3213E83F190655DA");

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
                        .HasConstraintName("FK__employees__emplo__1EF99443"),
                    l => l.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__proje__1E05700A"),
                    j =>
                    {
                        j.HasKey("ProjectId", "EmployeeId").HasName("PK__employee__202B7EA56F4A74D5");
                        j.ToTable("employees_projects");
                        j.HasIndex(new[] { "EmployeeId" }, "idx_employees_projects_employees");
                        j.HasIndex(new[] { "ProjectId" }, "idx_employees_projects_projects");
                        j.IndexerProperty<int>("ProjectId").HasColumnName("project_id");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                    });
        });

        modelBuilder.Entity<ProjectsDiscProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__projects__3213E83F7296DF38");

            entity.ToTable("projects_disc_profiles");

            entity.HasIndex(e => e.DiscProfileId, "idx_project_disc_profile_disc_profile");

            entity.HasIndex(e => e.ProjectId, "idx_project_disc_profile_project");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiscProfileId).HasColumnName("disc_profile_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");

            entity.HasOne(d => d.DiscProfile).WithMany(p => p.ProjectsDiscProfiles)
                .HasForeignKey(d => d.DiscProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__projects___disc___22CA2527");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectsDiscProfiles)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__projects___proje__21D600EE");
        });

        modelBuilder.Entity<SocialEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__social_e__3213E83F5DF41794");

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
                .HasConstraintName("FK__social_ev__compa__75035A77");

            entity.HasOne(d => d.DiscProfile).WithMany(p => p.SocialEvents)
                .HasForeignKey(d => d.DiscProfileId)
                .HasConstraintName("FK__social_ev__disc___740F363E");

            entity.HasMany(d => d.Employees).WithMany(p => p.SocialEvents)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeesSocialEvent",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__emplo__1B29035F"),
                    l => l.HasOne<SocialEvent>().WithMany()
                        .HasForeignKey("SocialEventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employees__socia__1A34DF26"),
                    j =>
                    {
                        j.HasKey("SocialEventId", "EmployeeId").HasName("PK__employee__EF36199A2CB4E7B8");
                        j.ToTable("employees_social_events");
                        j.HasIndex(new[] { "EmployeeId" }, "idx_employees_social_events_employees");
                        j.HasIndex(new[] { "SocialEventId" }, "idx_employees_social_events_social");
                        j.IndexerProperty<int>("SocialEventId").HasColumnName("social_event_id");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                    });
        });

        modelBuilder.Entity<StressMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__stress_m__3213E83F7E0A23B0");

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
                .HasConstraintName("FK__stress_me__emplo__1293BD5E");

            entity.HasOne(d => d.Task).WithMany(p => p.StressMeasures)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stress_me__task___1387E197");
        });

        modelBuilder.Entity<Models.Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tasks__3213E83FCA47CE68");

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
                .HasConstraintName("FK__tasks__project_i__0EC32C7A");

            entity.HasOne(d => d.TimeToCompleteNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TimeToComplete)
                .HasConstraintName("FK__tasks__time_to_c__0FB750B3");

            entity.HasMany(d => d.Employees).WithMany(p => p.Tasks)
                .UsingEntity<Dictionary<string, object>>(
                    "TasksEmployee",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tasks_emp__emplo__1758727B"),
                    l => l.HasOne<Models.Task>().WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tasks_emp__task___16644E42"),
                    j =>
                    {
                        j.HasKey("TaskId", "EmployeeId").HasName("PK__tasks_em__98C0F437ABED52FD");
                        j.ToTable("tasks_employees");
                        j.HasIndex(new[] { "EmployeeId" }, "idx_tasks_employees_employees");
                        j.HasIndex(new[] { "TaskId" }, "idx_tasks_employees_tasks");
                        j.IndexerProperty<int>("TaskId").HasColumnName("task_id");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                    });
        });

        modelBuilder.Entity<TaskCompleteInterval>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__task_com__3213E83FDDD53142");

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
