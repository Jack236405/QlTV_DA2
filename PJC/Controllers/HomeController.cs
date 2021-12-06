﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PJC.Models;
using System.Diagnostics;

namespace PJC.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        const string SessionQuyen = "_Quyen";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            var model = TempData["NguoiDunglogin"];
            TempData["NguoiDunglogin"] = model;
           
            return View();
        }
        public IActionResult Index1()
        {
            var model = TempData["NguoiDunglogin"];
            TempData["NguoiDunglogin"] = model;
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
