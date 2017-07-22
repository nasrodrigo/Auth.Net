using System;
using System.Collections.Generic;

namespace dotapp.Models
{
    //Service locator Pattern
    public class RepositoryServiceLocator : IRepositoryServiceLocator
    {
        private IDictionary<object, object> repositories;

        public RepositoryServiceLocator()
        {
            repositories = new Dictionary<object, object>();

            this.repositories.Add(typeof(IUserRepository), new UserRepository());
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
