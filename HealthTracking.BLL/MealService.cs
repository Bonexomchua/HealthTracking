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
    public class MealService
    {
        private readonly MealRep _rep;
        public MealService(MealRep rep)
        {
            _rep = rep;
        }

        public async Task<Meal> CreateMeal(MealDTO dto)
        {
            var meal = new Meal();
            meal.Id = dto.Id;
            meal.UserId = dto.UserId;
            meal.Date = dto.Date;
            meal.MealType = dto.MealType;
            return await _rep.CreateMeal(meal);
        }

        public async Task<List<Meal>> GetAll(String userId)
        {
            return await _rep.GetAll(userId);   
        }
    }
}
