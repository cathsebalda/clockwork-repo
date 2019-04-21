using Clockwork.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Clockwork.Web.Services.IServices
{
    public interface ITimeLogService
    {
        Task<IEnumerable<TimeLogDTO>> GetAll();
        Task<TimeLogDTO> Get();
        Task<TimeLogDTO> GetByTimezone(string timezone);
        IEnumerable<SelectListItem> GetTimezones();
    }
}
