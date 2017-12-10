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
                TeamId = matchDto.TeamIdHome,
                Name = matchDto.TeamHome,
                Country = new Country
                {
                    CountryId = matchDto.CountryHomeId,
                    Name = matchDto.CountryHome
                }             
                
            });
            teams.Add(new Team
            {
                TeamId = matchDto.TeamIdGuest,
                Name = matchDto.TeamGuest,
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
                Score=matchDto.Score,
                SportId=matchDto.SportId,
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
                //TeamHome = match.Teams[0].Name,
                TeamIdGuest = match.Teams[1].TeamId,
                //TeamGuest = match.Teams[1].Name,
                Date = match.Date,
                /*CountryHomeId = match.Teams[0].Country.CountryId,
                CountryHome = match.Teams[0].Country.Name,
                CountryGuestId = match.Teams[1].Country.CountryId,
                CountryGuest = match.Teams[1].Country.Name,*/
                TournamentId = match.Tournament.TournamentId,
                /*Tournament = match.Tournament.Name,*/
                Score = match.Score,
                ResultId = match.Result.ResultId
                //Result = match.Result.Name
            };

            return matchDto;
        }

        public IReadOnlyList<Match> ToMatches(IReadOnlyList<SortDto> sortesDto)
        {
            var matches = new List<Match>();
            foreach (var sortDto in sortesDto)
            {
                var teams = new List<Team>();
                teams.Add(new Team
                {                    
                    Name = sortDto.TeamHome,
                    Country = new Country
                    {                        
                        Name = sortDto.TeamHomeCountry
                    }

                });
                teams.Add(new Team
                {
                    Name = sortDto.TeamGuest,
                    Country = new Country
                    {
                        Name = sortDto.TeamGuestCountry
                    }
                });
                var match = new Match
                {
                    MatchId = sortDto.MatchId,
                    Teams = teams,
                    Date = sortDto.DateMatch,
                    Score=sortDto.Score,
                    Tournament=new Tournament
                    {
                        Name = sortDto.Tournament
                    }
                };
                matches.Add(match);
            }
            return matches;
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

        public IReadOnlyList<Result> ToResult(IReadOnlyList<ResultDto> resultsDto)
        {
            var resultsList = new List<Result>();
            foreach (var resultDto in resultsDto)
            {
                var result = new Result
                {
                    ResultId=resultDto.ResultId,
                    Name=resultDto.Name
                };

                resultsList.Add(result);
            }
            return resultsList;
        }
    }
}
