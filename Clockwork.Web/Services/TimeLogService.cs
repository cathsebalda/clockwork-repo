using Clockwork.Web.Infrastructure;
using Clockwork.Web.Infrastructure.Resilience;
using Clockwork.Web.Models;
using Clockwork.Web.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Clockwork.Web.Services
{
    public class TimeLogService : ITimeLogService
    {
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;

        public TimeLogService(IHttpClient apiClient)
        {
            _apiClient = apiClient;
            _remoteServiceBaseUrl = string.Format("{0}{1}", WebConfigurationManager.AppSettings["ClockworkAPIUrl"], "CurrentTime");
        }

        public async Task<IEnumerable<TimeLogDTO>> GetAll()
        {
            var allQueriesUri = $"{_remoteServiceBaseUrl}/timelogs";

            var dataString = await _apiClient.GetStringAsync(allQueriesUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<TimeLogDTO>>(dataString);

            return response;
        }

        public async Task<TimeLogDTO> Get()
        {
            var getUri = $"{_remoteServiceBaseUrl}";

            var dataString = await _apiClient.GetStringAsync(getUri);

            var response = JsonConvert.DeserializeObject<TimeLogDTO>(dataString);

            return response;
        }

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