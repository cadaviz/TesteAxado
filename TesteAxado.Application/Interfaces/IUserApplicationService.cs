using TesteAxado.Domain.Entities;
using System.Collections.Generic;

namespace TesteAxado.Application.Interfaces
{
    public interface IUserApplicationService : IApplicationServiceBase<User>
    {
        IEnumerable<Rating> GetRatingsById(long userId);

        User AuthenticateUser(User user);
    }
}
