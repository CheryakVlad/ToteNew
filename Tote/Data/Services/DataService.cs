using Common.Models;
using Data.Business;
using Data.Clients;
using System.Collections.Generic;
using System;

namespace Data.Services
{
    public class DataService : IDataService
    {
        private readonly IBetListClient betListClient;
        private readonly ITournamentClient tournamentClient;
        private readonly ITeamClient teamClient;
        private readonly IConvert convert;

        public DataService(IBetListClient client, IConvert convert, ITournamentClient tournamentClient, ITeamClient teamClient)
        {
            this.betListClient = client;
            this.convert = convert;
            this.tournamentClient = tournamentClient;
            this.teamClient = teamClient;
        }

        public IReadOnlyList<Match> GetBets(int? sportId, int? tournamentId)
        {
            
            var dto = betListClient.GetBets(sportId, tournamentId);

            if (dto != null)
            {
                return convert.ToMatchList(dto);
            }
            return new List<Match>();
        }

        public IReadOnlyList<Match> GetBetsAll()
        {
            var dto = betListClient.GetBetsAll();

            if (dto != null)
            {
                return convert.ToMatchList(dto);
            }
            return new List<Match>();
            
        }

        public IReadOnlyList<Event> GetEvents()
        {
            var dto = betListClient.GetEvents();

            if (dto != null)
            {
                return convert.ToEvents(dto);
            }
            return new List<Event>();
        }

        public IReadOnlyList<Event> GetEvents(int id)
        {
            var dto = betListClient.GetEvents(id);

            if (dto != null)
            {
                return convert.ToEvents(dto);
            }
            return new List<Event>();
        }

        public IReadOnlyList<Match> GetMatchesAll()
        {
            var dto = betListClient.GetBetsAll();
            var eventDto = betListClient.GetEvents();

            if (dto != null)
            {
                return convert.ToMatchList(dto,eventDto);
            }
            return new List<Match>();
        }

        public Sport GetSport(int? id)
        {
            var dto = betListClient.GetSport(id);

            if (dto != null)
            {
                return convert.ToSport(dto);
            }
            return new Sport();
        }

        public IReadOnlyList<Sport> GetSports()
        {
            var dto = betListClient.GetSports();

            if (dto != null)
            {
                return convert.ToSport(dto);
            }
            return new List<Sport>();
        }

        public IReadOnlyList<Tournament> GetTournament(int? sportId)
        {
            var dto = betListClient.GetTournament(sportId);

            if (dto != null)
            {
                return convert.ToTournament(dto);
            }
            return new List<Tournament>();
        }

        public Tournament GetTournamentById(int tournamentId)
        {
            var dto = tournamentClient.GetTournamentById(tournamentId);

            if (dto != null)
            {
                return convert.ToTournament(dto);
            }
            return new Tournament();
        }

        public IReadOnlyList<Tournament> GetTournamentes()
        {
            var dto = betListClient.GetTournamentes();

            if (dto != null)
            {
                return convert.ToTournament(dto);
            }
            return new List<Tournament>();
        }

        public IReadOnlyList<Team> GetTeamsAll()
        {
            var dto = teamClient.GetTeamsAll();

            if (dto != null)
            {
                return convert.ToTeams(dto);
            }
            return new List<Team>();
        }

        public Team GetTeamById(int teamId)
        {
            var dto = teamClient.GetTeamById(teamId);
            if (dto != null)
            {
                return convert.ToTeam(dto);
            }
            return new Team();
        }

        public IReadOnlyList<Match> GetMatchsAll()
        {
            throw new NotImplementedException();
        }

        public Match GetMatchById(int matchId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Country> GetCountriesAll()
        {
            var dto = teamClient.GetCountriesAll();
            if (dto != null)
            {
                return convert.ToCountry(dto);
            }
            return new List<Country>();
        }

        public IReadOnlyList<Team> GetTeamsByTournament(int tournamentId)
        {
            var dto = teamClient.GetTeamsByTournament(tournamentId);

            if (dto != null)
            {
                return convert.ToTeams(dto);
            }
            return new List<Team>();
        }

        public IReadOnlyList<Basket> GetBasketByUser(string login)
        {
            var dto = betListClient.GetBasketByUser(login);

            if (dto != null)
            {
                return convert.ToBasket(dto);
            }
            return new List<Basket>();
        }
    }
}
