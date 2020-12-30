/*
http://localhost:5000/api/commands
*/
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers {
    /// <summary>CommandsController</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase {
        /// <summary>GetCommands</summary>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() {
            return new[] { "this", "is", "hard", "coded" };
        }
    }
}
