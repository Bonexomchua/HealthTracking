using HealthTracking.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL.Models
{
    public class Water
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        public AppUser User { get; set; }
    }
}
