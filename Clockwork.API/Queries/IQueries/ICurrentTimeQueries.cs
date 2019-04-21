using Clockwork.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Queries.IQueries
{
    public interface ICurrentTimeQueries
    {
        Task<List<CurrentTimeQuery>> GetAllTimeLogs();
        Task<CurrentTimeQuery> GetTime(string ip);
        Task<CurrentTimeQuery> GetTimeByTimezone(string ip, string timezone);
    }
}
