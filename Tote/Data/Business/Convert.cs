using System;
using System.Collections.Generic;
using Common.Models;
using Data.ToteService;

namespace Data.Business
{
    public class Convert : IConvert
    {
        public IList<Bet> ToBetsList(IList<BetListDto> betsListDto)
        {
            var betsList = new List<Bet>();
            foreach (var betListDto in betsListDto)
            {
                var teams = new List<Team>();
                teams.Add(new Team { Name = betListDto.CommandHome });
                teams.Add(new Team { Name = betListDto.CommandGuest });
                var betList = new Bet
                {
                    BetId = betListDto.BetId,
                    WinCommandHome = betListDto.WinCommandHome,
                    WinCommandGuest = betListDto.WinCommandGuest,
                    Draw = betListDto.Draw,
                    Match = new Match { /*Date = System.Convert.ToDateTime(betListDto.Date),*/ Teams=teams }
                    
                };

                betsList.Add(betList);
            }
            return betsList;
        }

        public IList<Bet> ToRatesList(IList<BetListDto> betsListDto)
        {
            var betsList = new List<Bet>();
            foreach(var betListDto in betsListDto)
            {
                var teams = new List<Team>();
                teams.Add(new Team { Name = betListDto.CommandHome });
                teams.Add(new Team { Name = betListDto.CommandGuest });
                var betList=new Bet
                {
                    BetId= betListDto.BetId,
                    WinCommandHome= betListDto.WinCommandHome,
                    WinCommandGuest= betListDto.WinCommandGuest,
                    Draw=betListDto.Draw,
                    Match = new Match{/*Date= System.Convert.ToDateTime(betListDto.Date), */Teams = teams }

                    /*RateId = rateListDto.RateId, CommandGuest=rateListDto.CommandGuest,
                 CommandHome=rateListDto.CommandHome, Date=rateListDto.Date, Draw=rateListDto.Draw,
                 MatchId=rateListDto.MatchId, WinCommandGuest=rateListDto.WinCommandGuest, WinCommandHome=rateListDto.WinCommandHome*/
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

        public IList<Sport> ToSport(IList<SportDto> sportsDto)
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

        public IList<Tournament> ToTournament(IList<TournamentDto> tournamentsDto)
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
