using System;
using System.Collections.Generic;
using System.Linq;
using TesteAxado.Domain.Entities;
using TesteAxado.Domain.Interfaces.Repositories;

namespace TesteAxado.Infra.Data.Repositories
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        public IEnumerable<Rating> GetAllCarriersRatings(long userId)
        {
            return Db.Ratings
                .Where(x=> x.UserId == userId);
        }

        public IEnumerable<Rating> GetAllUsersRatings(long carrierId)
        {
            return Db.Ratings
                .Where(x => x.CarrierId == carrierId);
        }
    }
}
