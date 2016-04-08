using TesteAxado.Domain.Entities;
using System.Collections.Generic;

namespace TesteAxado.Application.Interfaces
{
    public interface ICarrierApplicationService : IApplicationServiceBase<Carrier>
    {
        IEnumerable<Rating> GetRatingsById(long carrierId);
    }
}
