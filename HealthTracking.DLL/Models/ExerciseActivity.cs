using HealthTracking.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL.Models
{
    public class ExerciseActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string AuthorId { get; set; }
        public int SettingId { get; set; }
        public string VideoUrl { get; set; }
        public int Duration { get; set; }
        public int Rate { get; set; }

        public AppUser User { get; set; }
    }
}
