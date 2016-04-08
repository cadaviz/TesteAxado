using System.Web.Mvc;
using TesteAxado.Web.ViewModels;

namespace TesteAxado.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() : base()
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}