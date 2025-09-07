using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL.Models
{
    public class MealDetail
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public int FoodCategoryId { get; set; }
        public int Quantity { get; set; }

        public Meal Meal { get; set; }
        public FoodCategory FoodCategory { get; set; }
    }
}
