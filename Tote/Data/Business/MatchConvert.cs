using System.Collections.Generic;
using Common.Models;
using Data.TeamService;

namespace Data.Business
{
    public class MatchConvert : IMatchConvert
    {
        public IReadOnlyList<Event> ToEvent(IReadOnlyList<EventDto> eventsDto)
        {
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

        public EventDto[] ToEventDto(IReadOnlyList<Event> events)
        {
            var eventsDto = new List<EventDto>();
            foreach (var _event in events)
            {
                var eventDto = new EventDto
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
