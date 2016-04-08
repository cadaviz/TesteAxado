using TesteAxado.Application.Interfaces;
using TesteAxado.Domain.Entities;
using TesteAxado.Domain.Interfaces.Services;
using System.Collections.Generic;
using System;

namespace TesteAxado.Application.Services
{
  public   class UserApplicationService : ApplicationServiceBase<User>, IUserApplicationService
    {
        private readonly IUserService _userService;

        public UserApplicationService(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        public User AuthenticateUser(User user)
        {
            return _userService.AuthenticateUser(user);
        }

        public IEnumerable<Rating> GetRatingsById(long userId)
        {
            return _userService.GetRatingsById(userId);
        }
    }
}
