using System;
using System.Collections.Generic;
using System.Linq;
using TesteAxado.Application.Interfaces;
using TesteAxado.Domain.Entities;
using TesteAxado.Domain.Interfaces.Services;

namespace TesteAxado.Application.Services
{
    public class RatingApplicationService : ApplicationServiceBase<Rating>, IRatingApplicationService
    {
        private readonly IRatingService _ratingService;

        public RatingApplicationService(IRatingService ratingService) : base(ratingService)
        {
            _ratingService = ratingService;
        }

        public override void Add(Rating item)
        {
            item.User = null;
            item.Carrier = null;
            _ratingService.Add(item);
        }

        public IEnumerable<Rating> GetAllRatingsForAvaliation(User user, IEnumerable<Carrier> carriers)
        {
            //Obtém as avaliações de transportadoras feitas por esse cliente
            var myRatings = _ratingService.GetAllCarriersRatings(user.Id);

            //Instancia uma lista de avaliações para a tela
            List<Rating> ratings = new List<Rating>();

            //Cria avaliações em branco para as empresas não avaliadas
            foreach (var carrier in carriers)
            {
                if (myRatings.Any(x => x.CarrierId == carrier.Id))
                {
                    ratings.Add(myRatings.Where(x => x.CarrierId == carrier.Id).FirstOrDefault());
                }
                else
                {
                    ratings.Add(new Rating()
                    {
                        Carrier = carrier,
                        CarrierId = carrier.Id,
                        UserId = user.Id,
                        User = user
                    });
                }

            }

            return ratings;
        }

        public Rating GetRatingForAvaliation(User user, Carrier carrier)
        {
            //Obtém as avaliações de transportadoras feitas por esse cliente
            var myRatings = _ratingService.GetAllCarriersRatings(user.Id);

            //Instancia uma lista de avaliações para a tela
            Rating rating = new Rating();

            //Cria avaliações em branco para as empresas não avaliadas
            if (myRatings.Any(x => x.CarrierId == carrier.Id))
            {
                rating = myRatings.Where(x => x.CarrierId == carrier.Id).FirstOrDefault();
            }
            else
            {
                rating = new Rating()
                {
                    Carrier = carrier,
                    CarrierId = carrier.Id,
                    UserId = user.Id,
                    User = user
                };
            }

            return rating;
        }

        public IEnumerable<Rating> GetAllCarriersRatings(long userId)
        {
            return _ratingService.GetAllCarriersRatings(userId);
        }

        public IEnumerable<Rating> GetAllUsersRatings(long carrierId)
        {
            return _ratingService.GetAllUsersRatings(carrierId);
        }
    }
}
