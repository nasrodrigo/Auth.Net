using System;

namespace Auth.Net.Domain.Model.Repositorys
{
    public interface IRepository 
    {
        void save<T>(T obj);
    }
}
