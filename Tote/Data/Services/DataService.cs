using Common.Models;
using Data.Business;
using Data.Clients;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

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

        public IList<Bet> GetRates(int? sportId, int? tournamentId)
        {
            /*List<Bet> rateList = new List<Bet>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultDb"].ConnectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetBetsBySportTournament";
                    var param1 = new SqlParameter();
                    param1.DbType = DbType.Int32;
                    param1.ParameterName = "@SportId";
                    param1.Value = 1;
                    command.Parameters.Add(param1);
                    var param2 = new SqlParameter();
                    param2.DbType = DbType.Int32;
                    param2.ParameterName = "@TournamentId";
                    param2.Value = 1;
                    command.Parameters.Add(param2);*/
                   // connection.Open();
                    //var reader = command..ExecuteReader();
                    /*SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);*/
                    /*while(reader.Read())
                    {
                        var RateList = new RateList()
                        {
                            RateId = (int)reader[0],
                            CommandHome = reader[1].ToString()
                        };
                        rateList.Add(RateList);


                    }*/
                    //connection.Close();

               /* foreach(DataTable table in dataSet.Tables)
                    {
                        foreach(DataRow row in table.Rows)
                        {
                            var RateList = new RateList()
                            {
                                RateId = (int)row[0],
                                CommandHome = row[1].ToString()
                            };
                            rateList.Add(RateList);
                        }
                    }

                }

                
            }
            return rateList;*/
            var dto = rateListClient.GetBets(sportId, tournamentId);

            if (dto != null)
            {
                return convert.ToBetsList(dto);
            }
            return new List<Bet>();
        }

        public IList<Bet> GetRatesAll()
        {
            var dto = rateListClient.GetBetsAll();

            if (dto != null)
            {
                return convert.ToBetsList(dto);
            }
            return new List<Bet>();
            
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
