using System.Collections.Generic;
using Parser.Models;

namespace Parser.Data
{
    public interface ICommandRepo
    {
        IEnumerable<Command> getCommands();

        Command getCommandById(int id);

        Command parseCommand(Command command);
    }
}