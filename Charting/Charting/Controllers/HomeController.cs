using System.Web.Mvc;
using UCDArch.Web.Attributes;

namespace Charting.Controllers
{
    [HandleTransactionsManually]
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
