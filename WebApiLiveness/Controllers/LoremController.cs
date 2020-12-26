using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using WebApiLiveness.Services;
using Env = System.Environment;

namespace WebApiLiveness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoremController : ControllerBase
    {
        private readonly LoremService _loremService;

        public LoremController(LoremService loremService)
        {
            _loremService = loremService;
        }

        //GET api/lorem
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var localIp = Request.HttpContext.Connection.LocalIpAddress;
                var loremText = _loremService.GetSentence();
                var result = $"{Env.MachineName} ({localIp}){Env.NewLine}{loremText}";
                return result;
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
