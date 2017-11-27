﻿using System.Collections.Generic;
using System.Linq;
using Service.Contracts.Dto;
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Service.Contracts.Common;

namespace Service.Contracts.Contracts
{
   
    public class RateListService : IRateListService
    {
        
        public List<BetListDto> GetBets(int? sportId, int? tournamentId)
        {
            var betsListDto = new List<BetListDto>();

            if (sportId == 0)
            {
                betsListDto= GetBetsAll();
            }
            else
            {
                if (tournamentId == 0)
                {
                    betsListDto = GetBetsBySport((int)sportId);
                }
                else
                {
                    betsListDto = GetBetsBySportTournament((int)sportId,(int)tournamentId);
                }
            }


            return betsListDto;
        }
        
        public List<BetListDto> GetBetsAll()
        {
            var betListDto = new List<BetListDto>();

            Connection<BetListDto> connection = new Connection<BetListDto>();

            betListDto = connection.GetConnection(CommandType.StoredProcedure, "GetBetsAll");
            
            return betListDto;
        }
        

        public List<BetListDto> GetBetsBySport(int sportId)
        {
            var betListDto = new List<BetListDto>();

            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });

            Connection<BetListDto> connection = new Connection<BetListDto>();

            betListDto = connection.GetConnection(CommandType.StoredProcedure, "GetBetsBySport", parameters);

            return betListDto;
        }

        public List<BetListDto> GetBetsBySportTournament(int sportId, int tournamentId)
        {
            var betListDto = new List<BetListDto>();

            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@TournamentId", Value = tournamentId });

            Connection<BetListDto> connection = new Connection<BetListDto>();

            betListDto = connection.GetConnection(CommandType.StoredProcedure, "GetBetsBySportTournament", parameters);

            return betListDto;
        }

        public SportDto GetSport(int? id)
        {

            var sportDto = new SportDto();

            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = id });
            

            Connection<SportDto> connection = new Connection<SportDto>();

            sportDto = connection.GetConnection(CommandType.StoredProcedure, "GetSportById", parameters)[0];

            return sportDto;
            
        }

        public List<SportDto> GetSports()
        {
            var sportDto = new List<SportDto>();

            
            Connection<SportDto> connection = new Connection<SportDto>();

            sportDto = connection.GetConnection(CommandType.StoredProcedure, "GetSportsAll");

            return sportDto;           
        }

        public List<TournamentDto> GetTournament(int? sportId)
        {
            var tornamentDtos = new List<TournamentDto>();

            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@SportId", Value = sportId });


            Connection<TournamentDto> connection = new Connection<TournamentDto>();

            tornamentDtos = connection.GetConnection(CommandType.StoredProcedure, "GetTournamentsBySportId", parameters);

            return tornamentDtos;
            
        }

        public List<TournamentDto> GetTournamentes()
        {
            var tornamentDtos = new List<TournamentDto>(); 

            Connection<TournamentDto> connection = new Connection<TournamentDto>();

            tornamentDtos = connection.GetConnection(CommandType.StoredProcedure, "GetTournamentsAll");

            return tornamentDtos;
            
        }
        
    }
}
