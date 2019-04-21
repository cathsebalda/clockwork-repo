using Clockwork.API.Models;
using Clockwork.API.Queries.IQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Clockwork.API.Queries
{
    public class CurrentTimeQueries : ICurrentTimeQueries
    {
        
        public async Task<List<CurrentTimeQuery>> GetAllTimeLogs()
        {
            using (var db = new ClockworkContext())
            {
                return await db.CurrentTimeQueries.Select(v => v).ToListAsync();
            }
        }

        public async Task<CurrentTimeQuery> GetTime(string ip)
        {
            var utcTime = DateTime.UtcNow;
            var serverTime = DateTime.Now;

            var returnVal = new CurrentTimeQuery
            {
                UTCTime = utcTime,
                ClientIp = ip,
                Time = serverTime
            };

            using (var db = new ClockworkContext())
            {
                await db.CurrentTimeQueries.AddAsync(returnVal);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                foreach (var CurrentTimeQuery in db.CurrentTimeQueries)
                {
                    Console.WriteLine(" - {0}", CurrentTimeQuery.UTCTime);
                }
            }

            return returnVal;
        }
    }
}
