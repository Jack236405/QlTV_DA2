using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PJC.Models;

namespace PJC.Areas.User.Controllers
{[Area("User")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            double f = context.DemDoanhThuT1();
            double f2 = context.DemDoanhThuT2();
            double f3 = context.DemDoanhThuT3();
            double f4 = context.DemDoanhThuT4();
            double f5 = context.DemDoanhThuT5();
            double f6 = context.DemDoanhThuT6();
            double f7 = context.DemDoanhThuT7();
            double f8= context.DemDoanhThuT8();
            double f9 = context.DemDoanhThuT9();
            double f10 = context.DemDoanhThuT10();
            double f11 = context.DemDoanhThuT11();
            double f12 = context.DemDoanhThuT12();

            ViewBag.DoanhThu = f;
            ViewBag.DoanhThut2 = f2;
            ViewBag.DoanhThut3 = f3;
            ViewBag.DoanhThut4 = f4;
            ViewBag.DoanhThut5 = f5;
            ViewBag.DoanhThut6 = f6;
            ViewBag.DoanhThut7 = f7;
            ViewBag.DoanhThut8 = f8;
            ViewBag.DoanhThut9 = f9;
            ViewBag.DoanhThut10 = f10;
            ViewBag.DoanhThut11 = f11;
            ViewBag.DoanhThut12 = f12;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Personalinformation(string id)
        {
            id = HttpContext.Session.GetString("NguoiDung");
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            TaiKhoan s = context.Personalinformation(id);
            ViewData.Model = s;
            return View();
        }
    }
}
