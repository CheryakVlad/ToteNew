using System;
using System.Collections.Generic;
using System.Linq;
using Service.Contracts.Dto;



namespace Service.Contracts.Contracts
{
    public class TeamService : ITeamService
    {

        /*public TeamDto GetCommand(int? id)
        {
            var selectedCommand = from Command in db.Commands
                                  where Command.CommandId == id
                                  select Command;
            return selectedCommand.First();
        }

        public IEnumerable<TeamDto> GetCommands()
        {
            return db.Commands;
        }*/
        public TeamDto GetCommand(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamDto> GetCommands()
        {
            throw new NotImplementedException();
        }
    }
}
