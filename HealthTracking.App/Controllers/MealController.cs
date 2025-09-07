using HealthTracking.BLL;
using HealthTracking.Common.DTO;
using HealthTracking.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracking.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly MealService _svc;
        public MealController(MealService svc)
        {
            _svc = svc;
        }

        [HttpPost("create-meal")]
        public async Task<IActionResult> CreateMeal([FromBody] MealDTO dto)
        {
            var result = await _svc.CreateMeal(dto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("all-meal")]
        public async Task<IActionResult> GetAll([FromBody] UserIdDTO dto)
        {
            var result = await _svc.GetAll(dto.Id);
            if (result == null || !result.Any())
            {
                return NotFound(new { message = "No Sleep found for user." });
            }
            return Ok(result);
        }
    }
}
