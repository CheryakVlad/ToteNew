using System;
using Service.Contracts.Dto;
using Service.Contracts.Common;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Service.Contracts.Exception;
using System.ServiceModel;

namespace Service.Contracts.Contracts
{
    public class UserService : IUserService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BetListService));

        public UserDto AddUser()
        {
            throw new NotImplementedException();
        }

        public UserDto EditUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto ExistsUser(string login, string password)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Login", Value = login });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Password", Value = password });

            var connection = new Connection<UserDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetUserByLoginPassword", parameters)[0];
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetUserByLoginPassword";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public RoleDto[] GetRoles()
        {
            var connection = new Connection<RoleDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetRoles");
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetRoles";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public UserDto GetUser(int userId)
        {
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@UserId", Value = userId });            

            var connection = new Connection<UserDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetUserById", parameters)[0];
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetUserById";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public UserDto[] GetUsers()
        {
            var connection = new Connection<UserDto>();
            try
            {
                return connection.GetConnection(CommandType.StoredProcedure, "GetUsersAll");
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "GetUsersAll";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public UserDto[] GetUsersByRole(int RoleId)
        {
            throw new NotImplementedException();
        }
    }
}
