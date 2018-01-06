using Common.Models;
using Data.UserService;
using System.Collections.Generic;

namespace Data.Business
{
    public class UserConvert:IUserConvert
    {
        public User ToUser(UserDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }
            var role = new Role
            {
                RoleId = userDto.RoleId,
                Name = userDto.Role
            };
            var roles = new List<Role>();
            roles.Add(role);
            var user = new User
            {
                UserId = userDto.UserId,
                Login = userDto.Login,
                Password = userDto.Password,
                Email = userDto.Email,
                FIO = userDto.FIO,
                Money = userDto.Money,
                PhoneNumber = userDto.PhoneNumber,
                Roles = roles
            };

            return user;
        }

        public UserDto ToUserDto(User user)
        {
            if (user == null)
            {
                return null;
            }
            var userDto = new UserDto
            {
                UserId = user.UserId,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                FIO = user.FIO,
                Money = user.Money,
                RoleId = user.RoleId,
                PhoneNumber = user.PhoneNumber
            };

            return userDto;
        }

        public IReadOnlyList<User> ToUsers(IReadOnlyList<UserDto> usersDto)
        {
            if (usersDto.Count == 0)
            {
                return null;
            }
            var usersList = new List<User>();
            foreach (var userDto in usersDto)
            {
                usersList.Add(ToUser(userDto));
            }
            return usersList;
        }

        public IReadOnlyList<Role> ToRoles(IReadOnlyList<RoleDto> rolesDto)
        {
            if (rolesDto.Count == 0)
            {
                return null;
            }
            var roles = new List<Role>();
            foreach (var roleDto in rolesDto)
            {
                var role = new Role
                {
                    RoleId = roleDto.RoleId,
                    Name = roleDto.Name
                };

                roles.Add(role);
            }

            return roles;
        }
    }
}
