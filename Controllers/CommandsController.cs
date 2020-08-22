using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int Id)
        {
            var commandItem = _repository.GetCommandById(Id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateComand(CommandCreateDto command)
        {
            var commandModelRepo = _mapper.Map<Command>(command);
            _repository.CreateCommand(commandModelRepo);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModelRepo);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }


        //PUT api/commands/{1}
        [HttpPut("{id}")]
        public ActionResult<CommandReadDto> UpdateComand(int id, CommandUpdateDto command)
        {
            var commandModelRepo = _repository.GetCommandById(id);
            if (commandModelRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(command, commandModelRepo);
            _repository.UpdateCommand(commandModelRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelRepo = _repository.GetCommandById(id);
            if (commandModelRepo == null)
            {
                return NotFound();
            }

            var commadToPath = _mapper.Map<CommandUpdateDto>(commandModelRepo);
            patchDoc.ApplyTo(commadToPath, ModelState);

            if (!TryValidateModel(commadToPath))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commadToPath, commandModelRepo);
            _repository.UpdateCommand(commandModelRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int Id)
        {
            var commandItem = _repository.GetCommandById(Id);
            if (commandItem == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }

    }

}