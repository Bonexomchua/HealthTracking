using HealthTracking.BLL;
using HealthTracking.Common.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthTracking.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SleepController : ControllerBase
    {
        private readonly SleepService _svc;

        public SleepController(SleepService svc)
        {
            _svc = svc;
        }

        [Authorize]
        [HttpPost("create-sleep")]
        public async Task<IActionResult> CreateSleep([FromBody] SleepDTO dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return NotFound();
            }
            dto.UserId = userId;
            dto.Date = DateTime.UtcNow;
            var result = await _svc.CreateSleep(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("get-all-sleep")]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return NotFound();
            }
            var result = await _svc.GetAll(userId);
            if (result == null || !result.Any())
            {
                return NotFound(new { message = "No Sleep found for user." });
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
