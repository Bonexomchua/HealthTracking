using HealthTracking.BLL;
using HealthTracking.Common.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace HealthTracking.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterController : ControllerBase
    {
        private readonly WaterService _svc;

        public WaterController(WaterService svc)
        {
            _svc = svc;
        }

        [HttpPost("add-water")]
        public async Task<IActionResult> AddWater(WaterDTO water)
        {
            var result = await _svc.AddWater(water);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("get-current-water")]
        public async Task<IActionResult> GetWater()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized("User ID not found in token");

            var result = await _svc.GetCurrentWater(userId);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("get-all-water")]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized("User ID not found in token");
            var result = await _svc.GetAllWater(userId);
            return Ok(result);
        }

        [Authorize]
        [HttpPatch("update-water")]
        public async Task<IActionResult> UpdateWater([FromBody] WaterAmountDTO dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _svc.UpdateWater(userId,dto.Amount);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("get-latest-week")]
        public async Task<IActionResult> GetLatestWeek()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return NotFound();
            }
            var result = await _svc.GetCurrentWeek(userId);
            return Ok(result);
        }
    }
}
