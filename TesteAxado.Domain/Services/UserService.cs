using System;
using System.Collections.Generic;
using TesteAxado.Domain.Entities;
using TesteAxado.Domain.Interfaces.Repositories;
using TesteAxado.Domain.Interfaces.Services;

namespace TesteAxado.Domain.Services
{
   public  class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public User AuthenticateUser(User user)
        {
            return _userRepository.AuthenticateUser(user);
        }

        public IEnumerable<Rating> GetRatingsById(long userId)
        {
            return _userRepository.GetRatingsById(userId);
        }
    }
}
