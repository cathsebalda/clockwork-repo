using System;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using System.Net;
using System.Threading.Tasks;
using Clockwork.API.Queries.IQueries;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrentTimeController : Controller
    {
        private readonly ICurrentTimeQueries _currentTimeQueries;
        public CurrentTimeController(ICurrentTimeQueries currentTimeQueries)
        {
            _currentTimeQueries = currentTimeQueries;
        }

        // GET api/currenttime
        [HttpGet]
        [ProducesResponseType(typeof(CurrentTimeQuery), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await _currentTimeQueries.GetTime(ip);

            return Ok(result);
        }

        //public async Task<IActionResult> GetByTimezone(string timezone)
        //{

        //}

        [HttpGet("timelogs")]
        [ProducesResponseType(typeof(CurrentTimeQuery), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllTimeLogs()
        {
            var model = await _currentTimeQueries.GetAllTimeLogs();
            return Ok(model);
        }
    }
}
