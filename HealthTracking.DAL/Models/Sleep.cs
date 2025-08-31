using System;
using System.Collections.Generic;

namespace HealthTracking.DAL.Models;

public partial class Sleep
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public DateTime TimeStart { get; set; }

    public DateTime TimeEnd { get; set; }

    public virtual User User { get; set; } = null!;
}
