using System;
using System.Collections.Generic;

namespace HealthTracking.DAL.Models;

public partial class BodyMetric
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public string? Type { get; set; }

    public double? Value { get; set; }

    public virtual User User { get; set; } = null!;
}
