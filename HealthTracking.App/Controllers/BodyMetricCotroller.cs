using HealthTracking.BLL;
using HealthTracking.Common.DTO;
using HealthTracking.Common.Request;
using HealthTracking.Common.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace HealthTracking.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BodyMetricCotroller : ControllerBase
    {
        private readonly BodyMetricService _service;

        public BodyMetricCotroller(BodyMetricService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("init-bodymetric")]
        public IActionResult InitBodyMetric([FromBody] BodyMetricDTO bdDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var res = new SingleRsp();
            res = _service.InitBodyMetric(bdDTO,userId);
            return Ok(res);
        }

        [HttpPost("get-body-metric")]
        public async Task<IActionResult> GetBodyMetric([FromBody] UserIdDTO id)
        {
            var result = await _service.Get(id.Id);
            if (result == null || !result.Any())
            {
                return NotFound(new { message = "No BodyMetrics found for user." });
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("get-body-metric-latest")]
        public async Task<IActionResult> GetLatestMetric()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _service.GetLatest(userId);
            if(result == null || !result.Any())
            {
                return NotFound(new { message = "No BodyMetrics found" });
            }
            return Ok(result);
        }
    }
}
