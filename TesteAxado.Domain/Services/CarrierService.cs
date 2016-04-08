using System.Collections.Generic;
using TesteAxado.Domain.Entities;
using TesteAxado.Domain.Interfaces.Repositories;
using TesteAxado.Domain.Interfaces.Services;

namespace TesteAxado.Domain.Services
{
    public class CarrierService : ServiceBase<Carrier>, ICarrierService
    {
        private readonly ICarrierRepository _carrierRepository;

        public CarrierService(ICarrierRepository carrierRepository) : base(carrierRepository)
        {
            _carrierRepository = carrierRepository;
        }

        public IEnumerable<Rating> GetRatingsById(long carrierId)
        {
            return _carrierRepository.GetRatingsById(carrierId);
        }
    }
}
