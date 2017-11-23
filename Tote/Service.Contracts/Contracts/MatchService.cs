using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts.Dto;
using Service.Contracts.Context;

namespace Service.Contracts.Contracts
{
    public class MatchService : IMatchService
    {
        private readonly ToteContext db;
        public MatchDto GetMatch(int? id)
        {
            var selectedMatch = from Match in db.Matches
                                where Match.MatchId == id
                                select Match;
            return selectedMatch.First();
        }

        public IEnumerable<MatchDto> GetMatches()
        {
            return db.Matches;
        }
    }
}
