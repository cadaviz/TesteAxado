using AutoMapper;
using TesteAxado.Application.Interfaces;
using TesteAxado.Domain.Entities;
using TesteAxado.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

using TesteAxado.Web.Models;

namespace TesteAxado.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApplicationService _userApp;

        public UserController(IUserApplicationService userApp): base()
        {
            _userApp = userApp;
        }
       
        public ActionResult Details(long id)
        {
            var userDomain = _userApp.GetById(id);
            var userViewModel = Mapper.Map<User, UserViewModel>(userDomain);

            return View(userViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDomain = Mapper.Map<UserViewModel, User>(userViewModel);
                _userApp.Add(userDomain);

                base.SessionInstance.Login(Mapper.Map<User, UserViewModel>(_userApp.AuthenticateUser(userDomain)));
                
                return RedirectToAction("Index", "Home");
            }
            return View(userViewModel);
        }

        public ActionResult Login()
        {
            return View();
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDomain = _userApp.AuthenticateUser(Mapper.Map<UserViewModel, User>(userViewModel));

                if (userDomain != null)
                {
                    base.SessionInstance.Login(Mapper.Map<User, UserViewModel>(userDomain));

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(userViewModel);
        }
        public ActionResult Logout()
        {
            base.SessionInstance.Logout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(long id)
        {
            var userDomain = _userApp.GetById(id);
            var userViewModel = Mapper.Map<User, UserViewModel>(userDomain);

            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDomain = Mapper.Map<UserViewModel, User>(userViewModel);
                _userApp.Update(userDomain);

                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }
    }
}