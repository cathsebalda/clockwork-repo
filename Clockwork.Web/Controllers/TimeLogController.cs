using Clockwork.Web.Services.IServices;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity;

namespace Clockwork.Web.Controllers
{
    public class TimeLogController : Controller
    {
        [Dependency]
        public ITimeLogService TimeLog { get; set; }
        [System.Web.Mvc.HttpGet]
        public async Task<JsonResult> Time()
        {
            var model = await TimeLog.Get();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpGet]
        public async Task<JsonResult> TimeByTimezone(string timezone)
        {
            var model = await TimeLog.GetByTimezone(timezone);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
