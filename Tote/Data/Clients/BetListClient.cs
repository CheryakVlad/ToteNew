
using System.Collections.Generic;
using Data.ToteService;
using System.ServiceModel;
using System.Data.SqlClient;

namespace Data.Clients
{
    public class BetListClient : IBetListClient
    {
        public IList<BetListDto> GetBets(int? sportId, int? tournamentId)
        {
            var model = new List<BetListDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                try
                {
                    client.Open();
                    var bets = client.GetBets(sportId, tournamentId);
                    foreach (var bet in bets)
                    {
                        model.Add(bet);
                    }

                }
                catch(FaultException<SqlException> sqlEx)
                {
                    throw;
                }
                catch(CommunicationException commEx)
                {
                    throw;
                }
                finally
                {
                    client.Close();                
                }

            }

            return model;
        }

        public IList<BetListDto> GetBetsAll()
        {
            var model = new List<BetListDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                client.Open();

                var bets = client.GetBetsAll();
                foreach (var bet in bets)
                {
                    model.Add(bet);
                }

                client.Close();

            }

            return model;
        }

        public SportDto GetSport(int? id)
        {
            var model = new SportDto();
            using (var client = new ToteService.BetListServiceClient())
            {
                client.Open();                
                model = client.GetSport(id);          
                client.Close();

            }

            return model;
        }

        public IList<SportDto> GetSports()
        {
            var model = new List<SportDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                client.Open();

                var sports = client.GetSports();
                foreach (var sport in sports)
                {
                    model.Add(sport);
                }

                client.Close();

            }

            return model;
        }

        public IList<TournamentDto> GetTournament(int? sportId)
        {
            var model = new List<TournamentDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                client.Open();

                var tournaments = client.GetTournament(sportId);
                foreach (var tournament in tournaments)
                {
                    model.Add(tournament);
                }

                client.Close();

            }

            return model;
        }

        public IList<TournamentDto> GetTournamentes()
        {
            var model = new List<TournamentDto>();
            using (var client = new ToteService.BetListServiceClient())
            {
                client.Open();

                var tournaments = client.GetTournamentes();
                foreach (var tournament in tournaments)
                {
                    model.Add(tournament);
                }

                client.Close();

            }

            return model;
        }

        
    }
}
