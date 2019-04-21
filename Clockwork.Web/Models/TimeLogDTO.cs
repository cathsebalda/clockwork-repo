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

        public string TimeString
        {
            get
            {
                return Time.ToString("MM/dd/yyyy hh:mm:ss tt");
            }
        }
        public string UTCTimeString
        {
            get
            {
                return UTCTime.ToString("MM/dd/yyyy hh:mm:ss tt");
            }
        }

        
    }
}