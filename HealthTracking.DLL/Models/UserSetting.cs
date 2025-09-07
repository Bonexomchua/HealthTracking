using HealthTracking.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL.Models
{
    public class UserSetting
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SettingName {  get; set; }
        public double WaterAmount { get; set; }
        public double ExerciseDuration {  get; set; }
        public int ExerciseRate {  get; set; }
        public List<string> Food {  get; set; }
        public AppUser user { get; set; }   

    }
}
