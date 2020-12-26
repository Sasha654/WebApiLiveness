using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApiLiveness.Services;

namespace WebApiLiveness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController
    {
        private readonly LoremService _loremService;

        public HealthController(LoremService loremService)
        {
            _loremService = loremService;
        }

        //GET api/health
        [HttpGet]
        public StatusCodeResult Get()
        {
            if (_loremService.IsOk)
            {
                return new OkResult();
            }
            else
            {
                return new StatusCodeResult(
                    (int)HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
