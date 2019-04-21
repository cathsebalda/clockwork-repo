using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clockwork.Web.Models
{
    public class HomeModel
    {
        public string SelectedTimezone { get; set; }
        public IEnumerable<SelectListItem> Timezones { get; set; }
    }
}