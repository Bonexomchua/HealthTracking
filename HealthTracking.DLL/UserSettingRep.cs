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
    public class UserSettingRep
    {
        private readonly HealthTrackingContext _context;
        public UserSettingRep(HealthTrackingContext context)
        {
            _context = context;
        }

        public async Task<UserSetting> AddNewSetting(UserSetting setting)
        {
            try
            {
                _context.UserSettings.Add(setting);
                await _context.SaveChangesAsync();
                return setting;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserSetting>> GetAllSetting(string userId)
        {
            try
            {
                return await _context.UserSettings.Where(b => b.UserId == userId).ToListAsync();
            }       
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
