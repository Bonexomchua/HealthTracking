using HealthTracking.Common.DAL;
using HealthTracking.Common.Response;
using HealthTracking.DAL.Model;
using HealthTracking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.DAL
{
    public class BodyMetricRep : GenericRep<HealthTrackingContext, BodyMetric>
    {
        private HealthTrackingContext _context;
        public BodyMetricRep(HealthTrackingContext context)
        {
            _context = context;
        }


        public SingleRsp InitBodyMetric(BodyMetric bodyMetric)
        {
            
            var res = new SingleRsp();
                using (var tran = _context.Database.BeginTransaction())
                    try
                    {
                        var r = _context.BodyMetrics.Add(bodyMetric);
                        _context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
            return res;
        }

        public async Task<List<BodyMetric>> Get(string id)
        {
            return await _context.BodyMetrics
                .Where(b => b.UserId == id).ToListAsync();
        }


        public async Task<List<BodyMetric>> GetLatest(string id)
        {
            var result = new List<BodyMetric>();

            var latestDateHeight = await _context.BodyMetrics
                .Where(b => b.UserId == id && b.Type == "height")
                .MaxAsync(b => (DateTime?)b.Date);

            var latestDateWeight = await _context.BodyMetrics
                .Where(b => b.UserId == id && b.Type == "weight")
                .MaxAsync(b => (DateTime?)b.Date);

            var latestMetricsHeight = await _context.BodyMetrics
                .Where(b => b.UserId == id && b.Date == latestDateHeight && b.Type == "height")
                .FirstOrDefaultAsync();
            result.Add(latestMetricsHeight);

            var latestMetricsWeight = await _context.BodyMetrics
                .Where(b => b.UserId == id && b.Date == latestDateWeight && b.Type == "weight")
                .FirstOrDefaultAsync();
            result.Add(latestMetricsWeight);

            return result;
        }
    }
}
