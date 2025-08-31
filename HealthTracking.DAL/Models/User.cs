using System;
using System.Collections.Generic;

namespace HealthTracking.DAL.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Birthday { get; set; }

    public virtual ICollection<BodyMetric> BodyMetrics { get; set; } = new List<BodyMetric>();

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

    public virtual ICollection<Meal> Meals { get; set; } = new List<Meal>();

    public virtual ICollection<Sleep> Sleeps { get; set; } = new List<Sleep>();

    public virtual ICollection<Water> Water { get; set; } = new List<Water>();
}
