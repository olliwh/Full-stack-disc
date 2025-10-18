﻿using System;
using System.Collections.Generic;

namespace Disc_backend.Models;

public partial class EmployeesPrivateDatum
{
    public int EmployeeId { get; set; }

    public string? PrivateEmail { get; set; }

    public string? PrivatePhone { get; set; }

    public string Cpr { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
