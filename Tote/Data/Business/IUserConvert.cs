
using Common.Models;
using Data.UserService;
using System.Collections.Generic;

namespace Data.Business
{
    public interface IUserConvert
    {
        User ToUser(UserDto userDto);
        UserDto ToUserDto(User user);
        IReadOnlyList<User> ToUsers(IReadOnlyList<UserDto> usersDto);
        IReadOnlyList<Role> ToRoles(IReadOnlyList<RoleDto> rolesDto);
        
    }
}
