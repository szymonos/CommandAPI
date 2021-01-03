/*
http://localhost:5000/api/commands
*/
using System.Collections.Generic;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

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
        public CommandsController(ICommandApiRepo repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// GetAllCommands - get list of all commands
        /// </summary>
        /// <returns>List of all commands.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands() {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        /// <summary>
        /// GetCommandById - get single command by Id
        /// </summary>
        /// <param name="id">Command id.</param>
        /// <returns>Single command.</returns>
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id) {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null) {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }

        /// <summary>
        /// CreateCommand - create new command
        /// </summary>
        /// <param name="commandCreateDto">JSON payload with command definition.</param>
        /// <returns>Created command with Id.</returns>
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto) {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();
            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new { commandReadDto.Id }, commandReadDto);
        }

        /// <summary>
        /// UpdateCommand - update full existing command
        /// </summary>
        /// <param name="id">Id of updated command.</param>
        /// <param name="commandUpdateDto">JSON payload with command definition.</param>
        /// <returns>NoContent</returns>
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto) {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// PartialCommandUpdate - update partial existing command
        /// </summary>
        /// <param name="id">Id of updated command.</param>
        /// <param name="patchDoc">Patch document.</param>
        /// <returns>NoContent</returns>
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc) {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch)) {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// DeleteCommand - delete specified command
        /// </summary>
        /// <param name="id">Id od deleted command.</param>
        /// <returns>NoContent</returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id) {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
