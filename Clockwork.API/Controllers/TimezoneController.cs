using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Clockwork.API.Services.IServices;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class TimezoneController : Controller
    {
        private readonly ITimezoneService _timezoneService;
        public TimezoneController(ITimezoneService timezoneService)
        {
            _timezoneService = timezoneService;
        }

        // GET api/timezone
        [HttpGet]
        [ProducesResponseType(typeof(SelectListItem), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();
            var result = _timezoneService.GetTimezones();

            return Ok(result);
        }

    }
}
