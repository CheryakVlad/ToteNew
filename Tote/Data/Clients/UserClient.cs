using System;
using System.Collections.Generic;
using Data.UserService;
using System.ServiceModel;
using Common.Models;
using Data.Business;

namespace Data.Clients
{
    public class UserClient : IUserClient
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(UserClient));
        private readonly IConvert convert;

        public UserClient(IConvert convert)
        {
            this.convert = convert;
        }

        public bool AddUser(User user)
        {
            var userDto = new UserDto();
            userDto = convert.ToUserDto(user);
            var model = new bool();
            using (var client = new UserService.UserServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.AddUser(userDto);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool DeleteUser(int userId)
        {            
            var model = new bool();
            using (var client = new UserService.UserServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.DeleteUser(userId);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public UserDto ExistsUser(string login, string password)
        {
            var model = new UserDto();
            using (var client = new UserService.UserServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.ExistsUser(login, password);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }

            }
            return model;
        }

        public IReadOnlyList<RoleDto> GetRolesAll()
        {
            var model = new List<RoleDto>();
            using (var client = new UserService.UserServiceClient())
            {
                try
                {
                    client.Open();
                    var roles = client.GetRoles();
                    foreach (var role in roles)
                    {
                        model.Add(role);
                    }

                    client.Close();

                }
                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
            }

            return model;
        }

        public UserDto GetUser(int userId)
        {
            var model = new UserDto();
            using (var client = new UserService.UserServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetUser(userId);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }

            }
            return model;
        }
    

        public IReadOnlyList<UserDto> GetUsersAll()
        {
            var model = new List<UserDto>();
            using (var client = new UserService.UserServiceClient())
            {
                try
                {
                    client.Open();
                    var users = client.GetUsers();
                    foreach (var user in users)
                    {
                        model.Add(user);
                    }

                    client.Close();

                }
                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return null;
                }
            }

            return model;
        }

        public bool UpdateUser(User user)
        {
            var userDto = new UserDto();
            userDto = convert.ToUserDto(user);
            var model = new bool();            
            using (var client = new UserService.UserServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.UpdateUser(userDto);
                    client.Close();
                }

                catch (FaultException<CustomException> customEx)
                {
                    log.Error(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    log.Error(commEx.Message);
                    return false;
                }

            }
            return model;
        }
    }
}
