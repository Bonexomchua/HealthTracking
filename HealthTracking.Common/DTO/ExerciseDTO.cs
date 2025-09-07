using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.Common.DTO
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime Date { get; set; }
        public string? Activity { get; set; }
        public int Duration { get; set; }
        public double Calories { get; set; }
    }
}
