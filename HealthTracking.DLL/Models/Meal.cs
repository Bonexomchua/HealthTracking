using HealthTracking.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!; // FK đến AppUser
        public DateTime Date { get; set; }
        public string MealType { get; set; } = null!;

        public AppUser User { get; set; }
        public ICollection<MealDetail> MealDetails { get; set; }
    }
}
