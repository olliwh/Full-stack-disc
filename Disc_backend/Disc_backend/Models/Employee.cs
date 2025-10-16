using System;
using System.Collections.Generic;

namespace Disc_backend.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int CompanyId { get; set; }

    public int PersonId { get; set; }

    public int? DepartmentId { get; set; }

    public int? PositionId { get; set; }

    public int? DiscProfileId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Department? Department { get; set; }

    public virtual DiscProfile? DiscProfile { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Position? Position { get; set; }

    public virtual ICollection<StressMeasure> StressMeasures { get; set; } = new List<StressMeasure>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<SocialEvent> SocialEvents { get; set; } = new List<SocialEvent>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
