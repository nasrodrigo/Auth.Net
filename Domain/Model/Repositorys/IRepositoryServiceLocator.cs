using System;

namespace dotapp.Domain.Model.Repositorys
{
    public interface IRepositoryServiceLocator 
    {
        T GetRepository<T>();
    }
}
