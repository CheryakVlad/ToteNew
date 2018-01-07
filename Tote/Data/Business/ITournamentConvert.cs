
using Common.Models;
using Data.ToteService;
using System.Collections.Generic;

namespace Data.Business
{
    public interface ITournamentConvert
    {
        Tournament ToTournament(TournamentDto tournamentDto);
        IReadOnlyList<Tournament> ToTournament(IReadOnlyList<TournamentDto> tournamentsDto);
        TournamentDto ToTournamentDto(Tournament tournament);        
    }
}
