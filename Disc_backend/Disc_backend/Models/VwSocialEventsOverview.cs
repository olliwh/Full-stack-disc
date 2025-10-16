using System;
using System.Collections.Generic;

namespace Disc_backend.Models;

public partial class VwSocialEventsOverview
{
    public int SocialEventId { get; set; }

    public string EventName { get; set; } = null!;

    public string? EventDescription { get; set; }

    public string? CompanyName { get; set; }

    public string? DiscProfileName { get; set; }

    public string? DiscColor { get; set; }

    public string? DiscDescription { get; set; }
}
