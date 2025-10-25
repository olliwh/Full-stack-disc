using System;
using System.Collections.Generic;

namespace Disc_backend.Models;

public partial class EmployeesCredential
{
    public int EmployeeId { get; set; }

    public string? PasswordHash { get; set; }

    public bool? RequiresReset { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
