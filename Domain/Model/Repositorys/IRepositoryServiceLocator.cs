using System;

namespace Auth.Net.Domain.Model.Repositorys
{
    public interface IRepositoryServiceLocator 
    {
        T GetRepository<T>();
    }
}
