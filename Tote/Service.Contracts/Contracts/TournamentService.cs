using System.Collections.Generic;
using System.Linq;
using Service.Contracts.Dto;
using Service.Contracts.Context;

namespace Service.Contracts.Contracts
{
    public class TournamentService : ITournamentService
    {
        private readonly ToteContext db;
        public TournamentDto GetTournament(int? id)
        {
            var selectedTournament = from Tournament in db.Tournaments
                                     where Tournament.TournamentId == id
                                     select Tournament;
            return selectedTournament.First();
        }

        public IEnumerable<TournamentDto> GetTournamentes()
        {
            return db.Tournaments;
        }
    }
}
