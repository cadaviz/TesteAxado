using AutoMapper;
using TesteAxado.Application.Interfaces;
using TesteAxado.Domain.Entities;
using TesteAxado.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TesteAxado.Web.Controllers
{
    public class CarrierController : BaseController
    {
        private readonly ICarrierApplicationService _carrierApp;

        public CarrierController(ICarrierApplicationService carrierApp) :base()
        {
            _carrierApp = carrierApp;
        }

        public ActionResult Index()
        {
            if (!base.SessionInstance.IsAuthenticated)
                return RedirectToAction("Login", "User");

            var carrierViewModel = Mapper.Map<IEnumerable<Carrier>, IEnumerable<CarrierViewModel>>(_carrierApp.GetAll());

            return View(carrierViewModel);
        }

        public ActionResult Details(long id)
        {
            if (!base.SessionInstance.IsAuthenticated)
                return RedirectToAction("Login", "User");

            var carrierDomain = _carrierApp.GetById(id);
            var carrierViewModel = Mapper.Map<Carrier, CarrierViewModel>(carrierDomain);

            return View(carrierViewModel);
        }

        public ActionResult Create()
        {
            if (!base.SessionInstance.IsAuthenticated)
                return RedirectToAction("Login", "User");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarrierViewModel carrierViewModel)
        {
            if (!base.SessionInstance.IsAuthenticated)
                return RedirectToAction("Login", "User");

            if (ModelState.IsValid)
            {
                var carrierDomain = Mapper.Map<CarrierViewModel, Carrier>(carrierViewModel);
                _carrierApp.Add(carrierDomain);

                return RedirectToAction("Index");
            }
            return View(carrierViewModel);
        }

        public ActionResult Edit(long id)
        {
            if (!base.SessionInstance.IsAuthenticated)
                return RedirectToAction("Login", "User");

            var carrierDomain = _carrierApp.GetById(id);
            var carrierViewModel = Mapper.Map<Carrier, CarrierViewModel>(carrierDomain);

            return View(carrierViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarrierViewModel carrierViewModel)
        {
            if (!base.SessionInstance.IsAuthenticated)
                return RedirectToAction("Login", "User");

            if (ModelState.IsValid)
            {
                var carrierDomain = Mapper.Map<CarrierViewModel, Carrier>(carrierViewModel);
                _carrierApp.Update(carrierDomain);

                return RedirectToAction("Index");
            }
            return View(carrierViewModel);
        }
    }
}