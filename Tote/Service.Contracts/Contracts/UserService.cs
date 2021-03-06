﻿using System;
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

        private void GenerateFaultException(string title, string exceptionMessage)
        {
            var exception = new CustomException();
            exception.Title = title;
            log.Error(exception);
            throw new FaultException<CustomException>(exception, exceptionMessage);
        }

        public bool AddUser(UserDto userDto)
        {
            if (userDto == null || userDto.Login == String.Empty)
            {
                GenerateFaultException("AddUser", "ArgumentException");
            }
            var parameters = new List<Parameter>();            
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Login", Value = userDto.Login });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Password", Value = userDto.Password });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Email", Value = userDto.Email });
            parameters.Add(new Parameter { Type = DbType.Decimal, Name = "@Money", Value = userDto.Money });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@FIO", Value = userDto.FIO });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@RoleId", Value = userDto.RoleId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@PhoneNumber", Value = userDto.PhoneNumber });

            var connection = new Connection<UserDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "AddUser", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "AddUser";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }

        public bool DeleteUser(int userId)
        {
            if (userId <= 0)
            {
                GenerateFaultException("DeleteUser", "ArgumentException");
            }
            var parameters = new List<Parameter>();            
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@UserId", Value = userId });

            var connection = new Connection<UserDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "DeleteUser", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "DeleteUser";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);
            }
        }
                
        public UserDto ExistsUser(string login, string password)
        {
            if (login==String.Empty||password==String.Empty)
            {
                GenerateFaultException("GetUserByLoginPassword", "ArgumentException");
            }
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
            if (userId <=0)
            {
                GenerateFaultException("GetUserById", "ArgumentException");
            }
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

        public bool UpdateUser(UserDto userDto)
        {
            if (userDto == null)
            {
                GenerateFaultException("UpdateUser", "ArgumentException");
            }
            var parameters = new List<Parameter>();
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@UserId", Value = userDto.UserId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Login", Value = userDto.Login });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Password", Value = userDto.Password });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@Email", Value = userDto.Email });
            parameters.Add(new Parameter { Type = DbType.Decimal, Name = "@Money", Value = userDto.Money });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@FIO", Value = userDto.FIO });
            parameters.Add(new Parameter { Type = DbType.Int32, Name = "@RoleId", Value = userDto.RoleId });
            parameters.Add(new Parameter { Type = DbType.String, Name = "@PhoneNumber", Value = userDto.PhoneNumber });

            var connection = new Connection<UserDto>();
            try
            {
                return connection.GetConnectionUpdate(CommandType.StoredProcedure, "UpdateUser", parameters);
            }
            catch (SqlException sqlEx)
            {
                var exception = new CustomException();
                exception.Title = "UpdateUser";
                log.Error(sqlEx.Message);
                throw new FaultException<CustomException>(exception, sqlEx.Message);

            }
        }
    }
}
