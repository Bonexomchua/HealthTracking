using HealthTracking.Common.DTO;
using HealthTracking.DAL;
using HealthTracking.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.BLL
{
    public class UserService
    {
        private readonly AppUserRep _rep;
        public UserService(AppUserRep rep)
        {
            _rep = rep;
        }

        public async Task<AppUser> UpdateUserSetting(string userId, int settingId)
        {
            return await _rep.UpdateUserSetting(settingId,userId);
        }

        public async Task<List<UserDTO>> GetExperts()
        {
            var experts = await _rep.GetExperts();
            var result = experts.Select(u => new UserDTO
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                FullName = u.FullName,
                Gender = u.Gender,
                Birthday = u.Birthday,
                Avatar = u.AvatarUrl
            }).ToList();
            return result;
        }
    }
}
