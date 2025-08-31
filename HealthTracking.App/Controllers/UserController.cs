using HealthTracking.BLL;
using HealthTracking.Common.Request;
using HealthTracking.Common.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthTracking.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService userService;
        public UserController() {
            userService = new UserService();
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody] UserReq userReq)
        {
            var res = new SingleRsp();
            res=userService.CreateUser(userReq);
            return Ok(res);
        }

        [HttpPost("find-user")]
        public IActionResult FindUser([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = userService.Read(simpleReq.Id);
            var user = new { Name = "Trang", Age = simpleReq.Id };
            return Ok(res);
        }
    }
}
