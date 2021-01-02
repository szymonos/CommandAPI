/*
http://localhost:5000/api/commands
*/
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using AutoMapper;

using CommandAPI.Configuration;
using CommandAPI.Data;
using CommandAPI.Dtos;
using CommandAPI.Models;

namespace CommandAPI.Controllers {
    /// <summary>CommandsController</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase {

        private readonly ICommandApiRepo _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CommandsController> _logger;
        private readonly CmdApiSettings _settings;

        public CommandsController(
            ICommandApiRepo repository,
            IMapper mapper,
            ILogger<CommandsController> logger,
            IOptionsSnapshot<CmdApiSettings> settings
        ) {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _settings = settings.Value;
        }

        /// <summary>
        /// Get all commands
        /// </summary>
        /// <returns>application/json</returns>
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands() {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        /// <summary>
        /// Get single commandy by Id
        /// </summary>
        /// <param name="id">Id of the command</param>
        /// <returns>application/json</returns>
        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id) {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null) {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }
        /*
                public ActionResult<IEnumerable<string>> Get() {
                    var tst = _settings.TstSet;
                    return new[] { "this", "is", "hard", "coded", tst };
                }
        */
    }
}
