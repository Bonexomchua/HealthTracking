using HealthTracking.Common.DAL;
using HealthTracking.Common.Response;
using HealthTracking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL
{
    public class UserRepo : GenericRepo<HealthTrackingContext, User>
    {
        public UserRepo() { }

        public override User Read(int id)
        {
            var res = All.FirstOrDefault(x => x.Id == id);
            return res;
        }

        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new HealthTrackingContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Add(user);
                        context.SaveChanges();
                        tran.Commit();
                        Console.WriteLine("Duoc roi ne");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        Console.WriteLine("Loi me roi");
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
