using System;

using Auth.Net.Domain.Model.Users;

namespace Auth.Net.Interfaces.Users.Facade
{
    public interface IUserFacadeService
    {
        void save(User user);
        User findByLoginAndPassword(String login, String password);
    }
}