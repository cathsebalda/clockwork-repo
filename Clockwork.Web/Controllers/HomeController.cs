using Clockwork.Web.Models;
using Clockwork.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
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

            var model = new HomeModel()
            {
                SelectedTimezone = TimeZone.CurrentTimeZone.StandardName,
                Timezones = TimeLog.GetTimezones()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetTime()
        {
            var model = await TimeLog.Get();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            var model =  await TimeLog.GetAll();
            return PartialView("_List", model);
        }
    }
}
