using System.Collections.Generic;
using TesteAxado.Domain.Entities;

namespace TesteAxado.Domain.Interfaces.Services
{
    public interface ICarrierService : IServiceBase<Carrier>
    {
        IEnumerable<Rating> GetRatingsById(long carrierId);
    }
}
