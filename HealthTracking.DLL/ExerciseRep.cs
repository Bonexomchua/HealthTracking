using HealthTracking.Common.DTO;
using HealthTracking.DAL.Model;
using HealthTracking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL
{
    public class ExerciseRep
    {
        private HealthTrackingContext _context;
        public ExerciseRep(HealthTrackingContext context)
        {
            _context = context;
        }

        public async Task<Exercise> AddExercise(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task<Exercise> UpdateExercise(String userId, int duration, DateTime today)
        {
            var ex = await _context.Exercises
.FirstOrDefaultAsync(w => w.UserId == userId && w.Date.Date == today.Date);
            if (ex == null)
            {
                var exercise = new Exercise();
                exercise.UserId=userId;
                exercise.Date = today;
                exercise.Duration = duration;
                await AddExercise(exercise);
                return exercise;
            }
            else
            {
                ex.Duration = duration;
            }
            await _context.SaveChangesAsync();
            return ex;
        }

        public async Task<List<Exercise>> GetAll(string userid)
        {
            return await _context.Exercises
                .Where(b => b.UserId == userid).ToListAsync();
        }

        public async Task<List<ExerciseActivity>> GetAlla(string userid)
        {
            return await _context.ExerciseActivity
                .Where(b => b.UserId == userid).ToListAsync();
        }

        public async Task<List<Exercise>> GetLastWeek(string userId)
        {
            var today = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            var sevenDaysAgo = today.AddDays(-7);

            var exs = await _context.Exercises
                .Where(s => s.UserId == userId && s.Date >= sevenDaysAgo && s.Date <= today)
                .OrderByDescending(s => s.Date)
                .ToListAsync();

            return exs;
        }

        public async Task<ExerciseActivity> CreateActivity(ExerciseActivity activity)
        {
                _context.ExerciseActivity.Add(activity);
                await _context.SaveChangesAsync();
                return activity;
        }

        public async Task<List<ExerciseActivity>> GetUserActivity(int settingId, string userId)
        {
            return await _context.ExerciseActivity
                .Where(ea => ea.SettingId == settingId && ea.UserId == userId)
                .ToListAsync();
        }


    }
}
