using System;
using System.Collections.Generic;
using Common.Models;
using Data.ToteService;
using Data.UserService;

namespace Data.Business
{
    public class Convert : IConvert
    {
        public IReadOnlyList<Event> GetEvents(IReadOnlyList<EventDto> eventsDto)
        {
            var eventsList = new List<Event>();
            foreach (var eventDto in eventsDto)
            {                
                var _event = new Event
                {
                    EventId=eventDto.EventId,
                    Name=eventDto.Name,
                    Coefficient=eventDto.Coefficient,
                    MatchId=eventDto.MatchId
                };

                eventsList.Add(_event);
            }
            return eventsList;
        }

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

        public IReadOnlyList<Event> ToEvents(IReadOnlyList<EventDto> eventsDto)
        {
            var eventsList = new List<Event>();
            foreach (var eventDto in eventsDto)
            {
                var _event = new Event
                {
                    EventId = eventDto.EventId,
                    Name = eventDto.Name,
                    Coefficient = eventDto.Coefficient,
                    MatchId = eventDto.MatchId
                };

                eventsList.Add(_event);
            }
            return eventsList;
        }

        public IReadOnlyList<Match> ToMatchList(IReadOnlyList<BetListDto> betsListDto)
        {
            var matchesList = new List<Match>();
            foreach (var betListDto in betsListDto)
            {
                var teams = new List<Team>();
                teams.Add(new Team { Name = betListDto.CommandHome, Country = new Country { Name = betListDto.CountryHome } });
                teams.Add(new Team { Name = betListDto.CommandGuest, Country = new Country { Name = betListDto.CountryGuest } });
                var match = new Match
                {
                    MatchId= betListDto.MatchId,
                    Teams=teams,
                    Date=betListDto.Date                                        
                };

                matchesList.Add(match);
            }
            return matchesList;
        }

        public IReadOnlyList<Match> ToMatchList(IReadOnlyList<BetListDto> betsListDto, IReadOnlyList<EventDto> eventsDto)
        {
            var matchesList = new List<Match>();
            foreach (var betListDto in betsListDto)
            {
                var teams = new List<Team>();
                teams.Add(new Team { Name = betListDto.CommandHome, Country = new Country { Name = betListDto.CountryHome } });
                teams.Add(new Team { Name = betListDto.CommandGuest, Country = new Country { Name = betListDto.CountryGuest } });
                var events = new List<Event>();
                foreach(var eventDto in eventsDto)
                {
                    if(eventDto.MatchId== betListDto.MatchId)
                    {
                        var _event = new Event()
                        {
                            EventId = eventDto.EventId,
                            Name = eventDto.Name,
                            Coefficient = eventDto.Coefficient,
                            MatchId = eventDto.MatchId
                        };
                        events.Add(_event);
                    }
                }
                var match = new Match
                {
                    MatchId = betListDto.MatchId,
                    Teams = teams,
                    Date = betListDto.Date,
                    Events=events
                };

                matchesList.Add(match);
            }
            return matchesList;
        }

        public IReadOnlyList<Role> ToRoles(IReadOnlyList<RoleDto> rolesDto)
        {
            var roles = new List<Role>();
            foreach (var roleDto in rolesDto)
            {
                var role = new Role
                {
                    RoleId=roleDto.RoleId,
                    Name=roleDto.Name
                };

                roles.Add(role);
            }

            return roles;
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

        public SportDto ToSportDto(Sport sport)
        {
            var sportDto = new SportDto
            {
                SportId=sport.SportId,
                Name=sport.Name
            };

            return sportDto;
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

        public User ToUser(UserDto userDto)
        {
            var role = new Role
            {
                Name = userDto.Role
            };
            var roles = new List<Role>();
            roles.Add(role);
            var user = new User
            {
                UserId = userDto.UserId,
                Login = userDto.Login,
                Password = userDto.Password,
                Email = userDto.Email,
                FIO = userDto.FIO,
                Money = userDto.Money,
                Roles=roles
            };
               
            return user;
        }

        public UserDto ToUserDto(User user)
        {
            var userDto = new UserDto
            {
                UserId = user.UserId,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                FIO = user.FIO,
                Money = user.Money,
                RoleId = user.RoleId
            };            
             
            return userDto;
        }

        public IReadOnlyList<User> ToUsers(IReadOnlyList<UserDto> usersDto)
        {
            var usersList = new List<User>();
            foreach (var userDto in usersDto)
            {
                var role = new Role
                {
                    Name = userDto.Role
                };
                var roles = new List<Role>();
                roles.Add(role);

                var user = new  User
                {
                    UserId=userDto.UserId,
                    Login=userDto.Login,
                    Password=userDto.Password,
                    Email=userDto.Email,
                    FIO=userDto.FIO,
                    Money = userDto.Money,
                    Roles = roles
                };

                usersList.Add(user);
            }
            return usersList;
        }
    }
}
