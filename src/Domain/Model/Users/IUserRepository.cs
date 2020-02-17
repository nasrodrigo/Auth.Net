using System;

using Auth.Net.Domain.Model.Repositorys;

namespace Auth.Net.Domain.Model.Users
{
    public interface IUserRepository: IRepository
    {
        User findByLoginAndPassword(String login, String password);
    }
}
