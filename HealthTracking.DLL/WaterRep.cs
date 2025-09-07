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
    public class WaterRep
    {
        private HealthTrackingContext _context;
        public WaterRep(HealthTrackingContext context)
        {
            _context = context;
        }

        public async Task<Water> AddWater(Water water)
        {
            _context.Waters.Add(water);
            await _context.SaveChangesAsync();
            return water;
        }

        public async Task<Water> GetCurrentWater(String userId, DateTime date)
        {
            return await _context.Waters.FirstOrDefaultAsync(w => w.UserId == userId && w.Date.Date == date.Date);
        }

        public async Task<List<Water>> GetAllWater(String userId)
        {
            return await _context.Waters.Where(w=>w.UserId == userId).ToListAsync();
        }

        public async Task<Water> UpdateWater(String userId, double amount, DateTime today)
        {
            var water = await _context.Waters
        .FirstOrDefaultAsync(w => w.UserId == userId && w.Date.Date == today.Date);
            if(water == null)
            {
                var newwater = new Water();
                newwater.UserId = userId;
                newwater.Date = today;
                newwater.Amount = amount;
                await AddWater(newwater);
                return newwater;
            }
            else
            {
                water.Amount = amount;
            }
            await _context.SaveChangesAsync();
            return water;
        }

        public async Task<List<Water>> GetLastWeek(string userId)
        {
            var today = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            var sevenDaysAgo = today.AddDays(-6);

            var waters = await _context.Waters
                .Where(s => s.UserId == userId && s.Date >= sevenDaysAgo && s.Date <= today)
                .OrderByDescending(s => s.Date)
                .ToListAsync();

            return waters;
        }
    }
}
