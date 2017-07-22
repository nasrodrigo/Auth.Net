using System;

using dotapp.Entitys;

namespace dotapp.Models
{
    public interface IUserRepository : IRepository
    {
        User findByLoginAndPassword(String login, String password);
    }
}
