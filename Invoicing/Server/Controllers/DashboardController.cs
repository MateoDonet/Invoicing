using Invoicing.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoicing.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IBusinessData _data;

        public DashboardController(IBusinessData data)
        {
            _data = data;
        }

        [HttpGet]
        public DashboardDto GetDashboard() =>
            new DashboardDto(_data);
    }
}
