using System;
using System.Collections.Generic;
using Data.UserService;
using System.ServiceModel;

namespace Data.Clients
{
    public class UserClient : IUserClient
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(UserClient));

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
    }
}
