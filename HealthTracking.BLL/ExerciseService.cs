using HealthTracking.Common.DTO;
using HealthTracking.DAL;
using HealthTracking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.BLL
{
    public class ExerciseService
    {
        private readonly ExerciseRep _rep;

        public ExerciseService(ExerciseRep rep)
        {
            _rep = rep;
        }

        public async Task<Exercise> AddExercise(ExerciseDTO exc)
        {
            var ex = new Exercise();
            ex.Id = exc.Id;
            ex.UserId = exc.UserId;
            ex.Duration = exc.Duration;
            ex.Date = DateTime.Now;
            ex.Activity = exc.Activity;
            ex.Calories = exc.Calories;
            return await _rep.AddExercise(ex);
        }

        public async Task<Exercise> UpdateExercise(string userId, int duration)
        {
            DateTime today = DateTime.Now.Date;
            return await _rep.UpdateExercise(userId, duration, today);
        }
             
        public async Task<List<Exercise>> GetAll(string userid)
        {
            return await _rep.GetAll(userid);
        }
        public async Task<List<ExerciseActivity>> GetAlla(string userid)
        {
            return await _rep.GetAlla(userid);
        }
        public async Task<List<Exercise>> GetCurrentWeek(String userId)
        {
            return await _rep.GetLastWeek(userId);
        }

        public async Task<ExerciseActivity> CreateActivity(ActivityDTO activity)
        {
            var exactivity = new ExerciseActivity();
            exactivity.Duration = activity.Duration;
            exactivity.Rate = activity.Rate;
            exactivity.VideoUrl = activity.VideoUrl;
            exactivity.AuthorId = activity.AuthorId;
            exactivity.UserId = activity.UserId;
            exactivity.Name = activity.Name;
            exactivity.SettingId = activity.SettingId;
            return await _rep.CreateActivity(exactivity);
        }

        public async Task<List<ExerciseActivity>> GetUserActivity(int settingId, string userId)
        {
            return await _rep.GetUserActivity(settingId, userId);
        }
    } 
}
