using System;
using System.Collections.Generic;
using Common.Models;
using Data.TeamService;

namespace Data.Business
{
    public class MatchConvert : IMatchConvert
    {
        public Match ToMatch(MatchDto matchDto)
        {
            var teams = new List<Team>();
            teams.Add(new Team
            {
                TeamId = matchDto.CountryHomeId,
                Name = matchDto.CountryHome,
                Country = new Country
                {
                    CountryId = matchDto.CountryHomeId,
                    Name = matchDto.CountryHome
                }             
                
            });
            teams.Add(new Team
            {
                TeamId = matchDto.CountryGuestId,
                Name = matchDto.CountryGuest,
                Country = new Country
                {
                    CountryId = matchDto.CountryGuestId,
                    Name = matchDto.CountryGuest
                }

            });
            var match = new Match
            {
                MatchId=matchDto.MatchId,
                Teams=teams,
                Date=matchDto.Date,
                Result=new Result
                {
                    ResultId= matchDto.ResultId,
                    Name=matchDto.Result
                },
                Tournament=new Tournament
                {
                    TournamentId=matchDto.TournamentId,
                    Name=matchDto.Tournament
                }
            };

            return match;
        }

        public MatchDto ToMatchDto(Match match)
        {
            var matchDto = new MatchDto
            {
                MatchId = match.MatchId,
                TeamIdHome = match.Teams[0].TeamId,
                TeamHome = match.Teams[0].Name,
                TeamIdGuest = match.Teams[1].TeamId,
                TeamGuest = match.Teams[1].Name,
                Date = match.Date,
                CountryHomeId = match.Teams[0].Country.CountryId,
                CountryHome = match.Teams[0].Country.Name,
                CountryGuestId = match.Teams[1].Country.CountryId,
                CountryGuest = match.Teams[1].Country.Name,
                TournamentId = match.Tournament.TournamentId,
                Tournament = match.Tournament.Name,
                Score = match.Score,
                ResultId = match.Result.ResultId,
                Result = match.Result.Name
            };

            return matchDto;
        }

        public IReadOnlyList<Match> ToMatches(IReadOnlyList<MatchDto> matchesDto)
        {
            var matches = new List<Match>();
            foreach(var matchDto in matchesDto)
            {
                matches.Add(ToMatch(matchDto));
            }
            return matches;
        }
    }
}
