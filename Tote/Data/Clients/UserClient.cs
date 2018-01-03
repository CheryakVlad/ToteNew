using System;
using System.Collections.Generic;
using Data.UserService;
using System.ServiceModel;
using Common.Models;
using Data.Business;
using Common.Logger;

namespace Data.Clients
{
    public class UserClient : IUserClient
    {        
        private readonly IConvert convert;
        private readonly ILogService<UserClient> logService;

        public UserClient(IConvert convert):this(convert, new LogService<UserClient>())
        {

        }

        public UserClient(IConvert convert, ILogService<UserClient> logService)
        {
            if (convert == null)
            {
                throw new ArgumentNullException();
            }
            this.convert = convert;
            if (logService == null)
            {
                this.logService = new LogService<UserClient>();
            }
            else
            {
                this.logService = logService;
            }
        }

        public bool AddUser(User user)
        {
            if (user == null)
            {
                logService.LogError("Class: UserClient Method: AddUser user is null");
                return false;
            }
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
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public bool DeleteUser(int userId)
        {
            if (userId <= 0)
            {
                logService.LogError("Class: UserClient Method: DeleteUser userId is not positive");
                return false;
            }
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
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }

        public UserDto ExistsUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login)||string.IsNullOrEmpty(password))
            {
                logService.LogError("Class: UserClient Method: DeleteUser login or password is Null Or Empty");
                return null;
            }
            var model = new UserDto();
            using (var client = new UserService.UserServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.ExistsUser(login, password);
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
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
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                    
                }
                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }
            }

            return model;
        }

        public UserDto GetUser(int userId)
        {
            if (userId<=0)
            {
                logService.LogError("Class: UserClient Method: DeleteUser userId is not positive");
                return null;
            }
            var model = new UserDto();
            using (var client = new UserService.UserServiceClient())
            {
                try
                {
                    client.Open();
                    model = client.GetUser(userId);
                    client.Close();
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }
                }

                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
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
                    if (model == null)
                    {
                        throw new NullReferenceException();
                    }

                }
                catch (FaultException<CustomException> customEx)
                {
                    logService.LogError(customEx.Message);
                    return null;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    logService.LogError(nullEx.Message);
                    return null;
                }
            }

            return model;
        }

        public bool UpdateUser(User user)
        {
            if (user == null)
            {
                logService.LogError("Class: UserClient Method: DeleteUser user is null");
                return false; 
            }
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
                    logService.LogError(customEx.Message);
                    return false;
                }
                catch (CommunicationException commEx)
                {
                    logService.LogError(commEx.Message);
                    return false;
                }

            }
            return model;
        }
    }
}
