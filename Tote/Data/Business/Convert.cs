using System;
using System.Collections.Generic;
using Common.Models;
using Data.ToteService;

namespace Data.Business
{
    public class Convert : IConvert
    {
        public IList<RateList> ToRatesList(IList<RateListDto> ratesListDto)
        {
            var ratesList = new List<RateList>();
            foreach(var rateListDto in ratesListDto )
            {
                var rateList=new RateList {RateId= rateListDto.RateId, CommandGuest=rateListDto.CommandGuest,
                 CommandHome=rateListDto.CommandHome, Date=rateListDto.Date, Draw=rateListDto.Draw,
                 MatchId=rateListDto.MatchId, WinCommandGuest=rateListDto.WinCommandGuest, WinCommandHome=rateListDto.WinCommandHome};
                ratesList.Add(rateList);
            }
            return ratesList;
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
