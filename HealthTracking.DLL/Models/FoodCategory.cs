using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL.Models
{
    public class FoodCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Type { get; set; }

        public ICollection<MealDetail> MealDetails { get; set; }
    }
}
