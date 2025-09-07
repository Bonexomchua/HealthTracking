using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.Common.DTO
{
    public class MealDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!; // FK đến AppUser
        public DateTime Date { get; set; }
        public string MealType { get; set; } = null!;
    }
}
