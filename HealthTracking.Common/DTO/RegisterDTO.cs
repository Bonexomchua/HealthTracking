using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.Common.DTO
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string FullName {  get; set; }
        public string Gender { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Role { get; set; }
    }
}
