using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TesteAxado.Application.Interfaces;
using TesteAxado.Domain.Entities;
using TesteAxado.Web.ViewModels;

namespace TesteAxado.Web.Controllers
{
    public class RatingController : BaseController
    {
        private readonly IRatingApplicationService _ratingApp;
        private readonly ICarrierApplicationService _carrierApp;
        private readonly IUserApplicationService _userApp;

        public RatingController(IRatingApplicationService ratingApp, ICarrierApplicationService carrierApp, IUserApplicationService userApp) : base()
        {
            _ratingApp = ratingApp;
            _carrierApp = carrierApp;
            _userApp = userApp;
        }

        public ActionResult Index()
        {
            if (!base.SessionInstance.IsAuthenticated)
                return RedirectToAction("Login", "User");

            var ratings = _ratingApp.GetAllRatingsForAvaliation(Mapper.Map<UserViewModel, User>(base.SessionInstance.AuthenticatedUser), _carrierApp.GetAll());

            return View(Mapper.Map<IEnumerable<Rating>, IEnumerable<RatingViewModel>>(ratings));
        }

        public void RateCarrier(long carrierId, int rateValue)
        {
            if (!base.SessionInstance.IsAuthenticated)
                return;

            Rating rating = _ratingApp.GetRatingForAvaliation(Mapper.Map<UserViewModel, User>(base.SessionInstance.AuthenticatedUser), _carrierApp.GetById(carrierId));
            rating.Rate = rateValue;

            if (rating.Id == 0)

                _ratingApp.Add(rating);
            else
                _ratingApp.Update(rating);
        }
    }
}