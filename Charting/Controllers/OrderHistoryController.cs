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
            _orders = OrderHistory.GenerateHistory(200).ToList();
        }

        public JsonNetResult OrdersByMonth()
        {
            var orderCountByMonth = from o in _orders
                                    group o by o.DateCreated.Month
                                        into months
                                        orderby months.Key
                                        select new { months.Key, Count = months.Count() };

            return new JsonNetResult(orderCountByMonth.Select(x => new[] { x.Key, x.Count}));
        }

        public JsonNetResult OrdersByMonthAndStatus()
        {
            var orderCountByMonthAndStatus = (from o in _orders
                                     group o by new { o.DateCreated.Month, o.Status }
                                         into monthStatus
                                         orderby monthStatus.Key.Month
                                         select new { monthStatus.Key.Month, monthStatus.Key.Status, Count = monthStatus.Count() }).ToList();

            var monthlyStatus = new List<dynamic>();

            foreach (var status in DataPool.Statuses)
            {
                var ordersForStatus = orderCountByMonthAndStatus.Where(x => x.Status == status);
                monthlyStatus.Add(new {label = status, data = ordersForStatus.Select(x => new[] {x.Month, x.Count})});
            }

            return new JsonNetResult(monthlyStatus);
        }

        public JsonNetResult OrdersByVendor()
        {
            var ordersByVendor = from o in _orders
                                 group o by o.Vendor
                                 into vendors
                                 orderby vendors.Key
                                 select new {vendors.Key, Count = vendors.Count()};

            return new JsonNetResult(ordersByVendor.Select(x => new {label = x.Key, data = x.Count}));
        }
    }
}
