using HealthTracking.BLL;
using HealthTracking.DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthTracking.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly UserService _svc;
        private readonly UserManager<AppUser> _user;
        public AppUserController(UserService svc, UserManager<AppUser> usermanager)
        {
            _svc = svc;
            _user = usermanager;
        }

        [Authorize]
        [HttpPatch("update-current-setting")]
        public async Task<IActionResult> UpdateCurrentSetting(int settingID)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _svc.UpdateUserSetting(userId, settingID);
            return Ok("Cập nhật thành công");
        }

        [HttpGet("experts")]
        public async Task<IActionResult> GetExperts()
        {
            var experts = await _svc.GetExperts();
            if (experts == null || !experts.Any())
            {
                return NotFound("No experts found");
            }

            return Ok(experts);
        }

        [Authorize]
        [HttpPost("upload-avatar")]
        public async Task<IActionResult> UploadAvatar(IFormFile avatar, [FromServices] IPhotoService photoService, [FromServices] UserManager<AppUser> userManager)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var avatarUrl = await photoService.UploadAvatarAsync(avatar);

            if (avatarUrl != null)
            {
                user.AvatarUrl = avatarUrl;
                await userManager.UpdateAsync(user);
            }

            return Ok(new { AvatarUrl = avatarUrl });
        }

        [RequestSizeLimit(100_000_000)]
        [Authorize]
        [HttpPost("upload-video")]
        public async Task<IActionResult> UploadVideo(IFormFile video, [FromServices] IPhotoService photoService)
        {

            var videoUrl = await photoService.UploadVideoAsync(video);

            return Ok(new { VideoUrl = videoUrl });
        }

            [Authorize]
            [HttpPost("get-username-by-ids")]
            public async Task<IActionResult> GetUsernameByIds([FromBody] List<string> ids)
            {
                var usernames = new List<Object>();
                foreach (var id in ids)
                {
                    var username = await _user.FindByIdAsync(id);
                    if (username != null)
                    {
                         usernames.Add(new
                            {
                                 id = username.Id,
                                 userName = username.UserName
                            });
                }
                }
                return Ok(usernames);
            }
    }
}
