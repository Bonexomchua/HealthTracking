using HealthTracking.DAL.Model;
using HealthTracking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL
{
    public class SleepRep
    {
        private readonly HealthTrackingContext _context;
        public SleepRep(HealthTrackingContext context)
        {
            _context = context;
        }

        public async Task<Sleep> CreateSleep(Sleep sleep)
        {
            _context.Sleeps.Add(sleep);
            await _context.SaveChangesAsync();
            return sleep;
        }

        public async Task<List<Sleep>> GetAll(String userId)
        {
            return await _context.Sleeps.Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<List<Sleep>> GetLastWeek(string userId)
        {
            var today = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            var sevenDaysAgo = today.AddDays(-7);

            var sleeps = await _context.Sleeps
                .Where(s => s.UserId == userId && s.Date >= sevenDaysAgo && s.Date <= today)
                .OrderByDescending(s => s.Date)
                .ToListAsync();

            return sleeps;
        }
    }
}
