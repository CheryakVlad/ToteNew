using System.Collections.Generic;
using Common.Models;
using Data.ToteService;
using Data.TeamService;
using System;

namespace Data.Business
{
    public class MatchConvert : IMatchConvert
    {
        public IReadOnlyList<Event> ToEvent(IReadOnlyList<TeamService.EventDto> eventsDto)
        {
            if(eventsDto.Count == 0)
            {
                return null;
            }
            var eventsList = new List<Event>();
            foreach (var eventDto in eventsDto)
            {
                var _event = new Event
                {
                    EventId=eventDto.EventId,
                    MatchId=eventDto.MatchId,
                    Coefficient=eventDto.Coefficient,
                    Name=eventDto.Name
                };

                eventsList.Add(_event);
            }
            return eventsList;
        }

        public TeamService.EventDto[] ToEventDto(IReadOnlyList<Event> events)
        {
            if (events.Count == 0)
            {
                return null;
            }
            var eventsDto = new List<TeamService.EventDto>();
            foreach (var _event in events)
            {
                var eventDto = new TeamService.EventDto
                {
                    EventId = _event.EventId,
                    MatchId = _event.MatchId,
                    Coefficient = _event.Coefficient,
                    Name = _event.Name
                };

                eventsDto.Add(eventDto);
            }
            return eventsDto.ToArray();
        }

        public Match ToMatch(MatchDto matchDto)
        {
            if (matchDto == null)
            {
                return null;
            }
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
            if (match == null)
            {
                return null;
            }
            var matchDto = new MatchDto
            {
                MatchId = match.MatchId,
                TeamIdHome = match.Teams[0].TeamId,                
                TeamIdGuest = match.Teams[1].TeamId,                
                Date = match.Date,               
                TournamentId = match.TournamentId,                
                Score = match.Score,
                ResultId = match.Result.ResultId                
            };

            return matchDto;
        }

        public IReadOnlyList<Match> ToMatches(IReadOnlyList<SortDto> sortesDto)
        {
            if(sortesDto.Count == 0)
            {
                return null;
            }
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
            if (matchesDto.Count == 0)
            {
                return null;
            }
            var matches = new List<Match>();
            foreach(var matchDto in matchesDto)
            {
                matches.Add(ToMatch(matchDto));
            }
            return matches;
        }

        public IReadOnlyList<Result> ToResult(IReadOnlyList<ResultDto> resultsDto)
        {
            if (resultsDto.Count == 0)
            {
                return null;
            }
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

        public IReadOnlyList<Match> ToMatchList(IReadOnlyList<ToteService.BetListDto> betsListDto)
        {
            if (betsListDto.Count == 0)
            {
                return null;
            }
            var matchesList = new List<Match>();
            foreach (var betListDto in betsListDto)
            {
                var teams = new List<Team>();
                teams.Add(new Team { Name = betListDto.CommandHome, Country = new Country { Name = betListDto.CountryHome } });
                teams.Add(new Team { Name = betListDto.CommandGuest, Country = new Country { Name = betListDto.CountryGuest } });
                var match = new Match
                {
                    MatchId = betListDto.MatchId,
                    Teams = teams,
                    Date = betListDto.Date
                };

                matchesList.Add(match);
            }
            return matchesList;
        }

        
    }
}
