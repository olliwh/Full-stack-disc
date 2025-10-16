using System;
using System.Collections.Generic;

namespace Disc_backend.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? PrivateEmail { get; set; }

    public string? PrivatePhone { get; set; }

    public string Cpr { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Experience { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
}
