﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCDArch.Web.ActionResults;

namespace Charting.Controllers
{
    public class D3Controller : Controller
    {
        public ActionResult Bullet()
        {
            return View();
        }

        public ActionResult BarSort()
        {
            return View();
        }

        public ActionResult BarSortData()
        {
            return new JsonNetResult(new[]
                {
                    new {letter = "A", frequency = 0.54612},
                    new {letter = "B", frequency = 0.23123},
                    new {letter = "C", frequency = 0.33123},
                    new {letter = "D", frequency = 0.13123}
                });
        }

        public ActionResult BulletData()
        {
            var data = new List<BulletData>
                {
                    new BulletData
                        {
                            title = "MAT 127A",
                            subtitle = "Scores against Department Avg",
                            ranges = new[] {3, 3.5, 4.2},
                            measures = new[] {3.67},
                            markers = new[] {3.75}
                        },
                    new BulletData
                        {
                            title = "Overall Scores",
                            subtitle = "Comparing all evals",
                            ranges = new[] {3, 3.5, 4.25},
                            measures = new[] {3.8},
                            markers = new[] {4.12}
                        }
                };

            return new JsonNetResult(data);
        }
    }

    public class BulletData
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public double[] ranges { get; set; }
        public double[] measures { get; set; }
        public double[] markers { get; set; }
    }
}
