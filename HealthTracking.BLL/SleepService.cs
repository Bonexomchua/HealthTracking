using HealthTracking.Common.DTO;
using HealthTracking.DAL;
using HealthTracking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracking.BLL
{
    public class SleepService
    {
        private readonly SleepRep _rep;

        public SleepService(SleepRep rep)
        {
            _rep = rep;
        }

        public async Task<Sleep> CreateSleep(SleepDTO dto)
        {
            var sleep = new Sleep();
            sleep.UserId = dto.UserId;
            sleep.TimeStart = dto.TimeStart;
            sleep.TimeEnd = dto.TimeEnd;
            sleep.Date = dto.Date;
            return await _rep.CreateSleep(sleep);
        }

        public async Task<List<Sleep>> GetAll(String userId)
        {
            return await _rep.GetAll(userId);
        }

        public async Task<List<Sleep>> GetCurrentWeek(String userId)
        {
            return await _rep.GetLastWeek(userId);
        }
    }
}
