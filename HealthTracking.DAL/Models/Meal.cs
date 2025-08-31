using System;
using System.Collections.Generic;

namespace HealthTracking.DAL.Models;

public partial class Meal
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public string MealType { get; set; } = null!;

    public virtual ICollection<MealDetail> MealDetails { get; set; } = new List<MealDetail>();

    public virtual User User { get; set; } = null!;
}
