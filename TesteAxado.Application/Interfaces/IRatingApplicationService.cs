using TesteAxado.Domain.Entities;
using System.Collections.Generic;

namespace TesteAxado.Application.Interfaces
{
    public interface IRatingApplicationService : IApplicationServiceBase<Rating>
    {
        IEnumerable<Rating> GetAllCarriersRatings(long userId);

        IEnumerable<Rating> GetAllUsersRatings(long carrierId);

        IEnumerable<Rating> GetAllRatingsForAvaliation(User user, IEnumerable<Carrier> carriers);
        Rating GetRatingForAvaliation(User user, Carrier carrier);
    }
}
