using System.Collections.Generic;
using TesteAxado.Domain.Entities;

namespace TesteAxado.Domain.Interfaces.Services
{
    public interface IRatingService : IServiceBase<Rating>
    {
        IEnumerable<Rating> GetAllCarriersRatings(long userId);

        IEnumerable<Rating> GetAllUsersRatings(long carrierId);
    }
}
