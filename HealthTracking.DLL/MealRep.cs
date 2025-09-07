using HealthTracking.DAL.Model;
using HealthTracking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL
{
    public class MealRep
    {
        private readonly HealthTrackingContext _context;

        public MealRep(HealthTrackingContext context)
        {
            _context = context;
        }

        public async Task<Meal> CreateMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();
            return meal;
        }

        public async Task<List<Meal>> GetAll(String userId)
        {
            return await _context.Meals.Where(b => b.UserId == userId).ToListAsync();
        }
    }
}
