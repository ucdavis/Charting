using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Charting.Models
{
    public class OrderHistory
    {
        public int OrderId { get; set; }
        public string WorkgroupName { get; set; }
        public string Vendor { get; set; }
        public string CreatedBy { get; set; }
        public string CreatorId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
        public bool IsComplete { get; set; }
        public decimal TotalAmount { get; set; }
        public string LineItems { get; set; }
        public string AccountSummary { get; set; }
        public bool HasAccountSplit { get; set; }
        public string ShipTo { get; set; }
        public string AllowBackorder { get; set; }
        public string Restricted { get; set; }
        public DateTime DateNeeded { get; set; }
        public string ShippingType { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime LastActionDate { get; set; }
        public string LastActionUser { get; set; }
        public string Received { get; set; }
        public string OrderType { get; set; }
        public decimal ShippingAmount { get; set; }
        public string Approver { get; set; }
        public string AccountManager { get; set; }
        public string Purchaser { get; set; }

        //Generates n history items
        public static IEnumerable<OrderHistory> GenerateHistory(int n)
        {
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                var order = new OrderHistory
                    {
                        OrderId = i + 1,
                        WorkgroupName = DataPool.Workgroups[rand.Next(4)],
                        Vendor = DataPool.Vendors[rand.Next(4)],
                        CreatedBy = DataPool.People[rand.Next(4)],
                        Status = DataPool.Statuses[rand.Next(3)],
                        DateCreated = DateTime.Now.AddDays(-rand.Next(250)),
                        TotalAmount = Convert.ToDecimal(rand.NextDouble()*200.00)
                    };

                yield return order;
            }
        }
    }

    public class DataPool
    {
        public static string[] Workgroups = {"Animal Science", "Biology", "Cartography", "Design", "Entemology"};
        public static string[] Vendors = {"Amazon.com", "Barnes And Noble", "Cartier", "Dunkin Donuts", "Etsy"};
        public static string[] People = { "Ansel Adams", "Billy Beane", "Chris Cross", "David Duchovny", "Ernie Els" };
        public static string[] Statuses = {"Approver", "Account Manager", "Purchaser", "Completed"};

    }
}