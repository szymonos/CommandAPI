/*
http://localhost:5000/api/commands
*/
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using CommandAPI.Configuration;
using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.Controllers {
    /// <summary>CommandsController</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase {

        private readonly ICommandApiRepo _repository;
        private readonly ILogger<CommandsController> _logger;
        private readonly CmdApiSettings _settings;

        public CommandsController(
            ICommandApiRepo repository,
            ILogger<CommandsController> logger,
            IOptionsSnapshot<CmdApiSettings> settings
        ) {
            _repository = repository;
            _logger = logger;
            _settings = settings.Value;
        }

        /// <summary>
        /// Get all commands
        /// </summary>
        /// <returns>application/json</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands() {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        /// <summary>
        /// Get single commandy by Id
        /// </summary>
        /// <param name="id">Id of the command</param>
        /// <returns>application/json</returns>
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id) {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null) {
                return NotFound();
            }
            return Ok(commandItem);
        }
        /*
                public ActionResult<IEnumerable<string>> Get() {
                    var tst = _settings.TstSet;
                    return new[] { "this", "is", "hard", "coded", tst };
                }
        */
    }
}
