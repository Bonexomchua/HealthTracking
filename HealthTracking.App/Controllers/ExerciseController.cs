using HealthTracking.BLL;
using HealthTracking.Common.DTO;
using HealthTracking.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthTracking.APP.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseService _svc;

        public ExerciseController(ExerciseService svc)
        {
            _svc = svc;
        }

        [Authorize]
        [HttpPost("add-ex")]
        public async Task<IActionResult> AddExercise(ExerciseDTO exercise)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return NotFound();
            }
            exercise.UserId = userId;
            var result = await _svc.AddExercise(exercise);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPatch("update-ex")]
        public async Task<IActionResult> UpdateExercise(int duration)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(userId == null)
            {
                return NotFound();
            }
            var result = await _svc.UpdateExercise(userId, duration);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("get-user-exercise")]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(userId == null)
            {
                return NotFound();
            }
            var result = await _svc.GetAll(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("get-user-exercisea")]
        public async Task<IActionResult> GetAlla()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return NotFound();
            }
            var result = await _svc.GetAlla(userId);
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

        [Authorize]
        [HttpPost("create-activity")]
        public async Task<IActionResult> CreateActivity(ActivityDTO dto)
        {
            var result = await _svc.CreateActivity(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("get-user-activity")]
        public async Task<IActionResult> GetUserActivity(int settingId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null) {
                var result = await _svc.GetUserActivity(settingId, userId);
                return Ok(result);
            }
            return Unauthorized();
        }
    }
}
