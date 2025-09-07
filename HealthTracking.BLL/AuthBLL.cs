using HealthTracking.Common.DTO;
using HealthTracking.DAL.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.BLL
{
    public class AuthBLL
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthBLL(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDTO dto)
        {
            var user = new AppUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FullName = dto.FullName,
                Gender = dto.Gender,
                Birthday = dto.BirthDay,
                AvatarUrl = "",
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if(result.Succeeded && dto.Role=="user")
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            else if(result.Succeeded && dto.Role=="expert")
            {
                await _userManager.AddToRoleAsync(user, "Expert");
            }
            return result;
        }

        public async Task<object?> LoginAsync(LoginDTO dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);
            if (user == null) return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded) return null;

            var roles = await _userManager.GetRolesAsync(user);
            var role=roles.FirstOrDefault();

            var uid = await _userManager.GetUserIdAsync(user);

            var currentSetting = user.CurrentSettingId;

            // Tạo token
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, role ?? ""),
        // Thêm role nếu cần

    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("safhhyrgfarfygarfkasneb2154eajghhegfgaey88755"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "your-api",
                audience: "your-client",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Role = role,
                Currentsetting = currentSetting,
                UID = uid,
                AvatarUrl = user.AvatarUrl,
            };
        }
    }
}
