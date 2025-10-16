﻿using System;
using System.Collections.Generic;

namespace Disc_backend.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public string? BusinessField { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<SocialEvent> SocialEvents { get; set; } = new List<SocialEvent>();
}
