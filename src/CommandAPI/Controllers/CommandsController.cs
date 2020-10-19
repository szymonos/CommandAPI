/*
http://localhost:5000/api/commands
*/
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    ///<Summary>
    /// CommandsController
    ///</Summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        ///<Summary>
        /// Get
        ///</Summary>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] { "this", "is", "hard", "coded" };
        }
    }
}
