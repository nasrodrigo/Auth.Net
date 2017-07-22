using System;

namespace dotapp.Models
{
    public interface IRepositoryServiceLocator 
    {
        T GetRepository<T>();
    }
}
