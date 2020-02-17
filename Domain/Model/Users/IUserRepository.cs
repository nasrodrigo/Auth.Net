using System;

using dotapp.Domain.Model.Repositorys;

namespace dotapp.Domain.Model.Users
{
    public interface IUserRepository: IRepository
    {
        User findByLoginAndPassword(String login, String password);
    }
}
