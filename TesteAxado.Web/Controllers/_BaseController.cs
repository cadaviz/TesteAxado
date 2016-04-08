using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteAxado.Web.Models;
using TesteAxado.Web.ViewModels;

namespace TesteAxado.Web.Controllers
{
    public class BaseController : Controller
    {
        public SessionInstance SessionInstance { get; set; }

        public BaseController() : base()
        {
            SessionInstance = MySession.Instance;
            ViewBag.SessionInstance = SessionInstance;
        }
    }
}