using System.Collections.Generic;
using Common.Models;
using Data.TeamService;
using Data.ToteService;
using Data.UserService;

namespace Data.Business
{
    public class Convert : IConvert
    {
        public IReadOnlyList<Event> GetEvents(IReadOnlyList<ToteService.EventDto> eventsDto)
        {
            if (eventsDto.Count == 0)
            {
                return null;
            }
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

        public Basket ToBasket(BasketDto basketDto)
        {
            if (basketDto == null)
            {
                return null;
            }
            var basket = new Basket
            {
                BasketId = basketDto.BasketId,
                UserId = basketDto.UserId,
                MatchId = basketDto.MatchId,
                EventId = basketDto.EventId
            };

            return basket;
        }

        public IReadOnlyList<Basket> ToBasket(IReadOnlyList<BasketDto> basketsDto)
        {
            if (basketsDto.Count == 0)
            {
                return null;
            }
            var baskets = new List<Basket>();
            foreach (var basketDto in basketsDto)
            {
                var basket = ToBasket(basketDto);
                baskets.Add(basket);
            }

            return baskets;
        }

        public BasketDto ToBasketDto(Basket basket)
        {
            if (basket == null)
            {
                return null;
            }
            var basketDto = new BasketDto
            {
                BasketId = basket.BasketId,
                UserId = basket.UserId,
                Login=basket.Login,
                MatchId = basket.MatchId,
                EventId = basket.EventId
            };

            return basketDto;
        }

        public IReadOnlyList<Bet> ToBet(IReadOnlyList<BetDto> betsDto)
        {
            if (betsDto.Count == 0)
            {
                return null;
            }
            var bets = new List<Bet>();
            
            foreach (var betDto in betsDto)
            {
                var bet = ToBet(betDto);
                bets.Add(bet);
            }

            return bets;
        }

        public Bet ToBet(BetDto betDto)
        {
            if (betDto == null)
            {
                return null;
            }
            var bet = new Bet
            {
                BetId =betDto.BetId,
                MatchId=betDto.MatchId,
                RateId=betDto.RateId,
                Status=betDto.Status,
                Event=new Event() { EventId=betDto.EventId},
                Sport=new Sport() { Name=betDto.Sport },
                Tournament=new Tournament() { Name=betDto.Tournament}
            };

            return bet;
        }

        public BetDto ToBetDto(Bet bet)
        {
            if (bet == null)
            {
                return null;
            }
            var betDto = new BetDto
            {
                BetId=bet.BetId,
                EventId=bet.Event.EventId,
                MatchId=bet.MatchId,
                RateId=bet.RateId,
                Status=bet.Status
            };

            return betDto;
        }

        public IReadOnlyList<Bet> ToBetsList(IReadOnlyList<BetListDto> betsListDto)
        {
            if (betsListDto.Count == 0)
            {
                return null;
            }
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

        public Country ToCountry(CountryDto countryDto)
        {
            if (countryDto == null)
            {
                return null;
            }
            var country = new Country
            {
                CountryId = countryDto.CountryId,
                Name = countryDto.Name
            };
            return country;
        }

        public IReadOnlyList<Country> ToCountry(IReadOnlyList<CountryDto> countriesDto)
        {
            if (countriesDto.Count == 0)
            {
                return null;
            }
            var countriesList = new List<Country>();
            foreach (var countryDto in countriesDto)
            {
                countriesList.Add(ToCountry(countryDto));
            }
            return countriesList;
        }

        public CountryDto ToCountryDto(Country country)
        {
            if (country == null)
            {
                return null;
            }
            var countryDto = new CountryDto
            {
                CountryId = country.CountryId,
                Name = country.Name
            };
            return countryDto;
        }

        public IReadOnlyList<Event> ToEvents(IReadOnlyList<ToteService.EventDto> eventsDto)
        {
            if (eventsDto.Count == 0)
            {
                return null;
            }
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
                    MatchId= betListDto.MatchId,
                    Teams=teams,
                    Date=betListDto.Date                                        
                };

                matchesList.Add(match);
            }
            return matchesList;
        }

        public IReadOnlyList<Match> ToMatchList(IReadOnlyList<BetListDto> betsListDto, IReadOnlyList<ToteService.EventDto> eventsDto)
        {
            if (betsListDto.Count == 0 || eventsDto.Count == 0)
            {
                return null;
            }
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

        public IReadOnlyList<Rate> ToRate(IReadOnlyList<RateDto> ratesDto)
        {
            if (ratesDto.Count == 0)
            {
                return null;
            }
            var rates = new List<Rate>();
            foreach (var rateDto in ratesDto)
            {
                rates.Add(ToRate(rateDto));
            }
            return rates;
        }

        public Rate ToRate(RateDto rateDto)
        {
            if (rateDto == null)
            {
                return null;
            }
            var Rate = new Rate
            {
                RateId=rateDto.RateId,
                DateRate=rateDto.DateRate,
                Amount=rateDto.Amount,
                UserId=rateDto.UserId,
                Status=rateDto.Status
            };

            return Rate;
        }

        public RateDto ToRateDto(Rate rate)
        {
            if (rate == null)
            {
                return null;
            }
            var rateDto = new RateDto
            {
                RateId=rate.RateId,
                Amount=rate.Amount,
                DateRate=rate.DateRate,
                UserId=rate.UserId
            };

            return rateDto;
        }

        

        public Sport ToSport(SportDto sportDto)
        {
            if (sportDto == null)
            {
                return null;
            }
            var sport = new Sport
            {
                SportId = sportDto.SportId,
                Name = sportDto.Name
            };

            return sport;
        }

        public IReadOnlyList<Sport> ToSport(IReadOnlyList<SportDto> sportsDto)
        {
            if (sportsDto.Count == 0)
            {
                return null;
            }
            var sports = new List<Sport>();
            foreach (var sportDto in sportsDto)
            {    
                sports.Add(ToSport(sportDto));
            }

            return sports;
        }

        public SportDto ToSportDto(Sport sport)
        {
            if (sport == null)
            {
                return null;
            }
            var sportDto = new SportDto
            {
                SportId=sport.SportId,
                Name=sport.Name
            };

            return sportDto;
        }

        public Team ToTeam(TeamDto teamDto)
        {
            if (teamDto == null)
            {
                return null;
            }
            var sport = new Sport
            {
                SportId=teamDto.SportId,
                Name=teamDto.Sport
            };
            var country = new Country
            {
                CountryId = teamDto.CountryId,
                Name = teamDto.Country
            };

            var team = new Team
            {
                TeamId=teamDto.TeamId,
                Name=teamDto.Name,
                SportId=teamDto.SportId,
                Sport=sport,
                CountryId=teamDto.CountryId,
                Country=country
            };

            return team;
        }

        public TeamDto ToTeamDto(Team team)
        {
            if (team == null)
            {
                return null;
            }
            var teamDto = new TeamDto
            {
                TeamId=team.TeamId,
                Name=team.Name,
                SportId=team.SportId,                
                CountryId=team.CountryId,                
            };

            return teamDto;
        }

        public IReadOnlyList<Team> ToTeams(IReadOnlyList<TeamDto> teamsDto)
        {
            if (teamsDto.Count == 0)
            {
                return null;
            }
            var teamsList = new List<Team>();
            foreach (var teamDto in teamsDto)
            {
                teamsList.Add(ToTeam(teamDto));
            }
            return teamsList;
        }

        /*public Tournament ToTournament(TournamentDto tournamentDto)
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
                Sport=new Sport
                {
                    SportId=tournamentDto.SportId,
                    Name= tournamentDto.Sport
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
                TournamentId=tournament.TournamentId,
                SportId = tournament.SportId,
                Name = tournament.Name
            };

            return tournamentDto;
        }*/
                
    }
}
