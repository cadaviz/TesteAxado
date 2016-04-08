using System.Collections.Generic;
using TesteAxado.Domain.Entities;

namespace TesteAxado.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        IEnumerable<Rating> GetRatingsById(long userId);

        User AuthenticateUser(User user);
    }
}
