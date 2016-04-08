using System;
using System.Collections.Generic;
using System.Linq;
using TesteAxado.Domain.Entities;
using TesteAxado.Domain.Interfaces.Repositories;

namespace TesteAxado.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public User AuthenticateUser(User user)
        {
            return Db.Users
                .Where(item => item.UserName == user.UserName && item.Password == user.Password)
                .FirstOrDefault();
        }

        public IEnumerable<Rating> GetRatingsById(long userId)
        {
            return Db.Ratings
                .Where(item => item.UserId == userId);
        }
    }
}
