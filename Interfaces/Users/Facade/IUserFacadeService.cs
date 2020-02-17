using System;

using dotapp.Domain.Model.Users;

namespace dotapp.Interfaces.Users.Facade
{
    public interface IUserFacadeService
    {
        void save(User user);
        User findByLoginAndPassword(String login, String password);
    }
}