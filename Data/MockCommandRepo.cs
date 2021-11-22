using System.Collections.Generic;
using Parser.Models;
using Parser.Utility;

namespace Parser.Data
{
    public class MockCommandRepo : ICommandRepo
    {
        public Command getCommandById(int id)
        {
            return new Command{body="A",length=0};
        }

        public IEnumerable<Command> getCommands()
        {
            List<Command> list = new List<Command>();
            list.Add(new Command{body="A",length=1});
            list.Add(new Command{body="B",length=1});
            list.Add(new Command{body="C",length=1});
            return list;
        }

        public Command parseCommand(Command command){
            var body = command.body;
            var util = new TLVParserUtility();
            return new Command{body=body,length=body.Length,parsed=util.getParsedTLV(body)};
        }
    }
}