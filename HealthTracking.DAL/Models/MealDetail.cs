using System;
using System.Collections.Generic;

namespace HealthTracking.DAL.Models;

public partial class MealDetail
{
    public int Id { get; set; }

    public int MealId { get; set; }

    public int FoodCategoryId { get; set; }

    public int? Quantity { get; set; }

    public virtual FoodCategory FoodCategory { get; set; } = null!;

    public virtual Meal Meal { get; set; } = null!;
}
