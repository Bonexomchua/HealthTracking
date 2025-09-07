using HealthTracking.Common.DTO;
using HealthTracking.DAL;
using HealthTracking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthTracking.Common.Response.MultipleRsp;

namespace HealthTracking.BLL
{
    public class UserSettingService
    {
        private readonly UserSettingRep _rep;
        public UserSettingService(UserSettingRep rep)
        {
            _rep = rep;
        }

        public async Task<UserSetting> AddNewSetting(UserSettingDTO dto)
        {
            var userSetting = new UserSetting();
            userSetting.UserId = dto.UserId;
            userSetting.SettingName = dto.SettingName;
            userSetting.WaterAmount = dto.WaterAmount;
            userSetting.ExerciseDuration = dto.ExerciseDuration;
            userSetting.ExerciseRate = dto.ExerciseRate;
            userSetting.Food = dto.Food;
            return await _rep.AddNewSetting(userSetting);
        }

        public async Task<UserSetting> AddDefaultSetting(string userId)
        {
            var userSetting = new UserSetting();
            var userSetting2 = new UserSetting();
            var userSetting3 = new UserSetting();
            userSetting.UserId = userId;
            userSetting.SettingName = "Default Setting";
            userSetting.WaterAmount = 1500;
            userSetting.ExerciseDuration = 15;
            userSetting.ExerciseRate = 2;
            userSetting.Food = new List<string> { "Đạm", "Xơ", "Protein" };
            return await _rep.AddNewSetting(userSetting);
        }

        public async Task<List<UserSetting>> GetAllSetting(string userId)
        {
            return await _rep.GetAllSetting(userId);
        }
    }
}
