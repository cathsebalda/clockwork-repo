using Clockwork.API.Services.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Services
{
    public class TimezoneService : ITimezoneService
    {
        public IEnumerable<SelectListItem> GetTimezones()
        {
            TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            {
                yield return new SelectListItem() { Value = z.Id, Text = z.DisplayName };
            }
        }
    }
}
