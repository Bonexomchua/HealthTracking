using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL.Model
{
    public class AppUser : IdentityUser
    {
        //Lấy bên file cũ
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public DateOnly? Birthday { get; set; }
        public string AvatarUrl { get; set; }
        public int? CurrentSettingId { get; set; }
    }
}
