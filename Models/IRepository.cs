using System;

namespace dotapp.Models
{
    public interface IRepository 
    {
        void save<T>(T obj);
    }
}
