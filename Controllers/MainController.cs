using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace aspnet_vuejs_basetemplate.Controllers
{
    //this will give you the main entry point for your app
    [Route("")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet]
        [Produces("text/html")]
        public async Task<IActionResult> Get()
        {
            var code = "";
            using (var stream = new FileStream("dist/index.html", FileMode.Open))
            {
                using (var sreader = new StreamReader(stream))
                {
                    code = await sreader.ReadToEndAsync();
                }
            }
            return new ContentResult()
            {
                Content = code,
                ContentType = "text/html",
            };
        }

        [HttpGet("serverData")]
        [Produces("application/json")]
        public ActionResult<string> ServerData(int id)
        {
            return Ok(new { Text = "Hi! I'm from server!" });
        }

    }
}
