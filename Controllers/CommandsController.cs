using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parser.Data;
using Parser.Models;

namespace Parser.Controllers
{
    [Route("api/command")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repository;

        public CommandsController(ICommandRepo repository)
        {
            _repository = repository;    
        }
        // private readonly MockCommandRepo _repository = new MockCommandRepo();

        [HttpGet]
        public ActionResult <IEnumerable<Command>> getAllCommands(){
            var commandItems = _repository.getCommands();
            return Ok(commandItems);    
        }
        
        [HttpGet("{id}")]
        public ActionResult<Command> getCommandById(int id){
            var commandItem = _repository.getCommandById(id);
            return Ok(commandItem);
        }

        [HttpPost]
        public ActionResult<Command> parseCommand(Command command){
            try{
                if(command == null || command.body == null || command.body == "")return BadRequest();

                var parsedCommand = _repository.parseCommand(command);
                return parsedCommand;
            }catch(FormatException fe){
                Console.WriteLine(fe);
                command.error = fe.Message;
                return command;
            }
            catch(Exception e){
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError,"Error Parsing Command");
            }
        }
    }
}