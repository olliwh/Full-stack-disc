using System;
using System.Collections.Generic;

namespace Disc_backend.Models;

public partial class TaskCompleteInterval
{
    public int Id { get; set; }

    public string? TimeToComplete { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
