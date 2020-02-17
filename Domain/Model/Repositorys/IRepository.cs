using System;

namespace dotapp.Domain.Model.Repositorys
{
    public interface IRepository 
    {
        void save<T>(T obj);
    }
}
