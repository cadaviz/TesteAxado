using System.Collections.Generic;
using TesteAxado.Application.Interfaces;
using TesteAxado.Domain.Entities;
using TesteAxado.Domain.Interfaces.Services;

namespace TesteAxado.Application.Services
{
    public  class CarrierApplicationService : ApplicationServiceBase<Carrier>, ICarrierApplicationService
    {
        private readonly ICarrierService _carrierService;

        public CarrierApplicationService(ICarrierService carrierService) : base(carrierService)
        {
            _carrierService = carrierService;
        }

        public IEnumerable<Rating> GetRatingsById(long carrierId)
        {
            return _carrierService.GetRatingsById(carrierId);
        }
    }
}
