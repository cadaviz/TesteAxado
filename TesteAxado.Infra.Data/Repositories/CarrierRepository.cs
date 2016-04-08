using System.Collections.Generic;
using System.Linq;
using TesteAxado.Domain.Entities;
using TesteAxado.Domain.Interfaces.Repositories;    

namespace TesteAxado.Infra.Data.Repositories
{
   public class CarrierRepository : RepositoryBase<Carrier>, ICarrierRepository
    {
        public IEnumerable<Rating> GetRatingsById(long carrierId)
        {
            return Db.Ratings
                .Where(item => item.CarrierId == carrierId);
        }
    }
}
