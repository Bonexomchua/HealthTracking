using HealthTracking.BLL;
using HealthTracking.Common.DTO;
using HealthTracking.DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthTracking.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSettingController : ControllerBase
    {
        private readonly UserSettingService _svc;
        private readonly UserManager<AppUser> _userManager;
        public UserSettingController(UserSettingService userSettingService, UserManager<AppUser> userManager)
        {
            _svc = userSettingService;
            _userManager = userManager;
        }


        [HttpPost("create-setting")]
        public async Task<IActionResult> AddNewSetting([FromBody] UserSettingDTO dto)
        {
            var result = await _svc.AddNewSetting(dto);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("get-all-setting")]
        public async Task<IActionResult> GetAllSetting()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(userId != null)
            {
                var res = await _svc.GetAllSetting(userId);
                return Ok(res);
            }

            return NoContent();
        }

    }
}
