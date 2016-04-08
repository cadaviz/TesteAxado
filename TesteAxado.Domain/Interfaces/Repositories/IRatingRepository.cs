using System.Collections.Generic;
using TesteAxado.Domain.Entities;

namespace TesteAxado.Domain.Interfaces.Repositories
{
    public interface IRatingRepository : IRepositoryBase<Rating>
    {
        IEnumerable<Rating> GetAllCarriersRatings(long userId);

        IEnumerable<Rating> GetAllUsersRatings(long carrierId);
    }
}
