using System;

namespace dotapp.Entitys
{
public interface IUser {
        bool IsUser(String login, String password, User user);
    }
}