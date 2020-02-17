using System;
using System.Collections.Generic;
using Auth.Net.Domain.Model.Users;

namespace Auth.Net.Domain.Model.Repositorys
{
    //Service locator Pattern
    public class RepositoryServiceLocator : IRepositoryServiceLocator
    {
        private IDictionary<object, object> repositories = new Dictionary<object, object>();

        public RepositoryServiceLocator( IDictionary<object, object> repositories )
        {
            this.repositories = repositories;
        }

        public T GetRepository<T>()
        {
            try
            {
                return (T)repositories[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("The requested repository is not registered");
                throw; 
            }
        }
        
    }

}
