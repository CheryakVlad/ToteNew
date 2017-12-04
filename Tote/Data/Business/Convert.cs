using System.Collections.Generic;
using Common.Models;
using Data.ToteService;

namespace Data.Business
{
    public class Convert : IConvert
    {
        public IReadOnlyList<Bet> ToBetsList(IReadOnlyList<BetListDto> betsListDto)
        {
            var betsList = new List<Bet>();
            foreach (var betListDto in betsListDto)
            {
                var teams = new List<Team>();
                teams.Add(new Team { Name = betListDto.CommandHome, Country = new Country { Name = betListDto.CountryHome } });
                teams.Add(new Team { Name = betListDto.CommandGuest, Country = new Country { Name = betListDto.CountryGuest } });
                var betList = new Bet
                {
                    BetId = betListDto.BetId,
                    WinCommandHome = betListDto.WinCommandHome,
                    WinCommandGuest = betListDto.WinCommandGuest,
                    Draw = betListDto.Draw,
                    Match = new Match { Date = System.Convert.ToDateTime(betListDto.Date), Teams=teams }
                    
                };

                betsList.Add(betList);
            }

            return betsList;
        }

        
        public Sport ToSport(SportDto sportDto)
        {
            var sport = new Sport
            {
                SportId = sportDto.SportId,
                Name = sportDto.Name
            };

            return sport;
        }

        public IReadOnlyList<Sport> ToSport(IReadOnlyList<SportDto> sportsDto)
        {
            var sports = new List<Sport>();
            foreach (var sportDto in sportsDto)
            {
                var sport = new Sport
                {
                    SportId=sportDto.SportId,
                    Name=sportDto.Name
                };

                sports.Add(sport);
            }

            return sports;
        }

        public IReadOnlyList<Tournament> ToTournament(IReadOnlyList<TournamentDto> tournamentsDto)
        {
            var tournaments = new List<Tournament>();
            foreach (var tournamentDto in tournamentsDto)
            {
                var sport = new Tournament
                {
                    TournamentId=tournamentDto.TournamentId,
                    Name=tournamentDto.Name,
                    SportId=tournamentDto.SportId
                };

                tournaments.Add(sport);
            }

            return tournaments;
        }
    }
}
