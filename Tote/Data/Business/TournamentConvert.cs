
using Common.Models;
using Data.ToteService;
using System.Collections.Generic;

namespace Data.Business
{
    public class TournamentConvert:ITournamentConvert
    {
        public Tournament ToTournament(TournamentDto tournamentDto)
        {
            if (tournamentDto == null)
            {
                return null;
            }
            var tournament = new Tournament
            {
                TournamentId = tournamentDto.TournamentId,
                Name = tournamentDto.Name,
                SportId = tournamentDto.SportId,
                Sport = new Sport
                {
                    SportId = tournamentDto.SportId,
                    Name = tournamentDto.Sport
                }
            };
            return tournament;
        }

        public IReadOnlyList<Tournament> ToTournament(IReadOnlyList<TournamentDto> tournamentsDto)
        {
            if (tournamentsDto.Count == 0)
            {
                return null;
            }
            var tournaments = new List<Tournament>();
            foreach (var tournamentDto in tournamentsDto)
            {
                tournaments.Add(ToTournament(tournamentDto));
            }

            return tournaments;
        }

        public TournamentDto ToTournamentDto(Tournament tournament)
        {
            if (tournament == null)
            {
                return null;
            }
            var tournamentDto = new TournamentDto
            {
                TournamentId = tournament.TournamentId,
                SportId = tournament.SportId,
                Name = tournament.Name
            };

            return tournamentDto;
        }
    }
}
