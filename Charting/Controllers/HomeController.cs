using System.Linq;
using System.Web.Mvc;
using Charting.Models;
using UCDArch.Web.Attributes;

namespace Charting.Controllers
{
    [HandleTransactionsManually]
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            Message = "Click the *Chart* dropdown to view different charts for this data";

            var orders = OrderHistory.GenerateHistory(200).ToList();

            return View(orders);
        }
    }
}
