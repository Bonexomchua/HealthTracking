using HealthTracking.Common.BLL;
using HealthTracking.Common.Request;
using HealthTracking.Common.Response;
using HealthTracking.DAL;
using HealthTracking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.BLL
{
    public class UserService : GenericService<UserRepo, User>
    {
        private UserRepo userRepo;
        public UserService() {
            userRepo = new UserRepo();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = userRepo.Read(id);
            return res;
        }

        public SingleRsp CreateUser(UserReq user)
        {
            var res = new SingleRsp();
            User userres = new User();
            userres.Id = user.Id;
            userres.Username = user.Username;
            userres.Password = user.Password;
            userres.FullName = user.FullName;
            userres.Gender = user.Gender;
            userres.Birthday = user.Birthday;
            res = userRepo.CreateUser(userres);
            Console.WriteLine("Da chay file service");
            return res;
        }
    }
}
