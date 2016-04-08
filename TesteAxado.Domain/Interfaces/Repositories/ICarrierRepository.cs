using System.Collections.Generic;
using TesteAxado.Domain.Entities;

namespace TesteAxado.Domain.Interfaces.Repositories
{
    public interface ICarrierRepository : IRepositoryBase<Carrier>
    {
        IEnumerable<Rating> GetRatingsById(long carrierId);
    }
}
