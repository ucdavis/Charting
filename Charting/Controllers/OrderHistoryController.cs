using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Charting.Models;
using UCDArch.Web.ActionResults;

namespace Charting.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class OrderHistoryController : Controller
    {
        private static List<OrderHistory> _orders;
        
        public OrderHistoryController()
        {
            _orders = OrderHistory.GenerateHistory(2000).ToList();
        }

        public JsonNetResult OrdersByMonth()
        {
            var orderCountByMonth = from o in _orders
                                    group o by o.DateCreated.Month
                                    into months
                                    orderby months.Key
                                    select new { months.Key, Count = months.Count() };

            return new JsonNetResult(orderCountByMonth.Select(x => new[] {x.Key, x.Count}));
        }
    }
}
