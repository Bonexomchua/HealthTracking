using System;
using System.Collections.Generic;

namespace HealthTracking.DAL.Models;

public partial class Water
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public double? Amount { get; set; }

    public virtual User User { get; set; } = null!;
}
