using System;
using System.Collections.Generic;

namespace Disc_backend.Models;

public partial class Education
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public int? Grade { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
