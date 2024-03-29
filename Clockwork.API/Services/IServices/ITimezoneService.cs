﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Services.IServices
{
    public interface ITimezoneService
    {
        IEnumerable<SelectListItem> GetTimezones();
    }
}
