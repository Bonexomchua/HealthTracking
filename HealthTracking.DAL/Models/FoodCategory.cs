using System;
using System.Collections.Generic;

namespace HealthTracking.DAL.Models;

public partial class FoodCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public virtual ICollection<MealDetail> MealDetails { get; set; } = new List<MealDetail>();
}
