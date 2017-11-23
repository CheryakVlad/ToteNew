using Common.Models;
using Data.Business;
using Data.Clients;
using System.Collections.Generic;
using System;

namespace Data.Services
{
    public class DataService : IDataService
    {
        private readonly IRateListClient rateListClient;
        private readonly IConvert convert;

        public DataService(IRateListClient client, IConvert convert)
        {
            this.rateListClient = client;
            this.convert = convert;
        }

        public IList<RateList> GetRates(int? sportId, int? tournamentId)
        {
            var dto = rateListClient.GetRates(sportId, tournamentId);

            if (dto != null)
            {
                return convert.ToRatesList(dto);
            }
            return new List<RateList>();
        }

        public IList<RateList> GetRatesAll()
        {
            var dto = rateListClient.GetRatesAll();

            if (dto != null)
            {
                return convert.ToRatesList(dto);
            }
            return new List<RateList>();
        }

        public Sport GetSport(int? id)
        {
            var dto = rateListClient.GetSport(id);

            if (dto != null)
            {
                return convert.ToSport(dto);
            }
            return new Sport();
        }

        public IList<Sport> GetSports()
        {
            var dto = rateListClient.GetSports();

            if (dto != null)
            {
                return convert.ToSport(dto);
            }
            return new List<Sport>();
        }

        public IList<Tournament> GetTournament(int? sportId)
        {
            var dto = rateListClient.GetTournament(sportId);

            if (dto != null)
            {
                return convert.ToTournament(dto);
            }
            return new List<Tournament>();
        }

        public IList<Tournament> GetTournamentes()
        {
            var dto = rateListClient.GetTournamentes();

            if (dto != null)
            {
                return convert.ToTournament(dto);
            }
            return new List<Tournament>();
        }
    }
}
