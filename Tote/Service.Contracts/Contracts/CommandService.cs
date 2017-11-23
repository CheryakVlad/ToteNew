using System.Collections.Generic;
using System.Linq;
using Service.Contracts.Dto;
using Service.Contracts.Context;


namespace Service.Contracts.Contracts
{
    public class CommandService : ICommandService
    {
        private readonly ToteContext db;
        public CommandDto GetCommand(int? id)
        {
            var selectedCommand = from Command in db.Commands
                                  where Command.CommandId == id
                                  select Command;
            return selectedCommand.First();
        }

        public IEnumerable<CommandDto> GetCommands()
        {
            return db.Commands;
        }

        

        
    }
}
