using HealthTracking.DAL;
using HealthTracking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthTracking.Common.DTO;

namespace HealthTracking.BLL
{
    public class WaterService
    {
        private readonly WaterRep _rep;

        public WaterService(WaterRep rep)
        {
            _rep = rep;
        }

        public async Task<Water> AddWater(WaterDTO dto)
        {
            var ex = new Water();
            ex.Id = dto.Id;
            ex.UserId = dto.UserId;
            ex.Date = dto.Date;
            ex.Amount = dto.Amount;
            return await _rep.AddWater(ex);
        }

        public async Task<Water> GetCurrentWater(String userId)
        {
            DateTime currDate = DateTime.Now.Date;
            return await _rep.GetCurrentWater(userId, currDate);
        }

        public async Task<List<Water>> GetAllWater(String userId)
        {
            return await _rep.GetAllWater(userId);
        }

        public async Task<Water> UpdateWater(String userId, double amount)
        {
            var today = DateTime.Now;  
            return await _rep.UpdateWater(userId,amount,today);
        }

        public async Task<List<Water>> GetCurrentWeek(String userId)
        {
            return await _rep.GetLastWeek(userId);
        }
    }
}
