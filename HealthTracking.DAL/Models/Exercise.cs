using System;
using System.Collections.Generic;

namespace HealthTracking.DAL.Models;

public partial class Exercise
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public string? Activity { get; set; }

    public int? Duration { get; set; }

    public double? Calories { get; set; }

    public virtual User User { get; set; } = null!;
}
