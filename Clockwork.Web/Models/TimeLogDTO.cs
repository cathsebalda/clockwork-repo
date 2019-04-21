using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clockwork.Web.Models
{
    public class TimeLogDTO
    {
        public string ClientIP { get; set; }
        public DateTime Time { get; set; }
        public DateTime UTCTime { get; set; }
        public string Timezone { get; set; }
    }
}