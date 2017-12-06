﻿using Common.Models;
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
    }
}
