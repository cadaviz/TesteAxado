using System;
using System.Collections.Generic;
using TesteAxado.Domain.Entities;
using TesteAxado.Domain.Interfaces.Repositories;
using TesteAxado.Domain.Interfaces.Services;

namespace TesteAxado.Domain.Services
{
    public class RatingService : ServiceBase<Rating>, IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository) : base(ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public IEnumerable<Rating> GetAllCarriersRatings(long userId)
        {
          return  _ratingRepository.GetAllCarriersRatings(userId);
        }

        public IEnumerable<Rating> GetAllUsersRatings(long carrierId)
        {
            return _ratingRepository.GetAllUsersRatings(carrierId);
        }
    }
}
