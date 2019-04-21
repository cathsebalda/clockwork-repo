using Clockwork.Web.Models;
using Clockwork.Web.Services.IServices;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity;

namespace Clockwork.Web.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public ITimeLogService TimeLog { get; set; }

        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            var model = new TimezoneModel()
            {
                SelectedTimezone = TimeZone.CurrentTimeZone.StandardName,
                Timezones = TimeLog.GetTimezones()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> TimeList()
        {
            var model =  await TimeLog.GetAll();
            return PartialView("_List", model);
        }
    }
}
