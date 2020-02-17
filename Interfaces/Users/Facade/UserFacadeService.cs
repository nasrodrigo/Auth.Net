using System;
using System.Collections.Generic;

using Auth.Net.Domain.Model.Users;
using Auth.Net.Domain.Model.Repositorys;

namespace Auth.Net.Interfaces.Users.Facade
{
    public class UserFacadeService : IUserFacadeService
    {
        private IDictionary<object, object> repositories = new Dictionary<object, object>();
        private static IRepositoryServiceLocator repositoryServiceLocator;
        private IUserRepository userRepository;
        public UserFacadeService()
        {
            this.repositories.Add(typeof(IUserRepository), new UserRepository());
            repositoryServiceLocator = new RepositoryServiceLocator(this.repositories);
            userRepository = repositoryServiceLocator.GetRepository<IUserRepository>();
        }

        public void save(User user)
        {
            userRepository.save<User>(user);
        }

        public User findByLoginAndPassword(String login, String password)
        {
            return userRepository.findByLoginAndPassword(login, password);
        }
    }
}