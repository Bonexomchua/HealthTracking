using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.Common.DTO
{
    public class UserSettingDTO
    {
        public string UserId { get; set; }
        public string SettingName { get; set; }
        public double WaterAmount { get; set; }
        public double ExerciseDuration { get; set; }
        public int ExerciseRate { get; set; }
        public List<String> Food { get; set; }
    }
}
