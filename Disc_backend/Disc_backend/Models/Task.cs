﻿using System;
using System.Collections.Generic;

namespace Disc_backend.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Completed { get; set; }

    public DateTime? TimeOfCompletion { get; set; }

    public int? TimeToComplete { get; set; }

    public string? Evaluation { get; set; }

    public int ProjectId { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<StressMeasure> StressMeasures { get; set; } = new List<StressMeasure>();

    public virtual TaskCompleteInterval? TimeToCompleteNavigation { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
