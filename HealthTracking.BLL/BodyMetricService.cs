using HealthTracking.Common.BLL;
using HealthTracking.Common.DTO;
using HealthTracking.Common.Response;
using HealthTracking.DAL;
using HealthTracking.DAL.Model;
using HealthTracking.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.BLL
{
    public class BodyMetricService : GenericSvc<BodyMetricRep, BodyMetric>
    {
        /*        private readonly BodyMetricRep _bodyMetricRep;

                public BodyMetricService(BodyMetricRep bodyMetricRep)
                {
                    _bodyMetricRep = bodyMetricRep;
                }*/

        public BodyMetricService(BodyMetricRep rep) : base(rep)
        {
        }

        public SingleRsp InitBodyMetric(BodyMetricDTO bodyMetric, string UserId)
        {
            var res = new SingleRsp();
            var bdmt = new BodyMetric();
            bdmt.Id = bodyMetric.Id;
            bdmt.UserId = UserId;
            bdmt.Date = DateTime.Now;
            bdmt.Type = bodyMetric.Type;
            bdmt.Value = bodyMetric.Value;
            res = _rep.InitBodyMetric(bdmt);
            return res;
        }


        public async Task<List<BodyMetric>> Get(string id)
        {
            return await _rep.Get(id);
        }

        public async Task<List<BodyMetric>> GetLatest(string userId)
        {
            return await _rep.GetLatest(userId);
        }
    }
}
