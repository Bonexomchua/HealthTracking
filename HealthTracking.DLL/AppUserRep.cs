using HealthTracking.DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL
{
    public class AppUserRep
    {
        private readonly HealthTrackingContext _context;
        public AppUserRep(HealthTrackingContext context)
        {
            _context = context;
        }

        public async Task<AppUser> UpdateUserSetting(int newId,string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            user.CurrentSettingId = newId;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<AppUser>> GetExperts()
        {
            var expertRoleId = await _context.Roles
                .Where(r => r.Name == "Expert")
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            if (expertRoleId == null) return new List<AppUser>();

            var experts = await (from ur in _context.UserRoles
                                 join u in _context.Users on ur.UserId equals u.Id
                                 where ur.RoleId == expertRoleId
                                 select u)
                                 .ToListAsync();

            return experts;
        }
    }
}
