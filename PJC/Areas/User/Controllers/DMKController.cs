﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PJC.Models;

namespace PJC.Areas.User
{
    [Area("User")]
    public class DMKController : Controller
    {
      
        
        [HttpGet]
        public IActionResult DoiMK()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            ViewBag.NguoiDung = HttpContext.Session.GetString("NguoiDung");
            return View();
        }
        [HttpPost]
        public IActionResult DoiMK(DoiMK d)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            ViewBag.NguoiDung = HttpContext.Session.GetString("NguoiDung");
            if (string.Compare(d.MatKhau, d.PassWordConfirm, false) == 0)
            {
                 count = context.DoiMK(d);
                if (count == 100)
                {
                    TempData["result"] = "Mật khẩu cũ không khớp";
                    return Redirect("~/User/DMK/DoiMK");
                }
                else if(count == 1)
                {
                    TempData["result"] = "Đổi mật khẩu thành công";
                    return View();
                    //return Redirect("~/User/DMK/DoiMK");
                }
                else
                {
                    TempData["result"] = "Đổi mật khẩu không thành công";
                    //return RedirectToAction("Index", "Home");
                    return Redirect("~/User/DMK/DoiMK");
                }
            }
            else
            {
                TempData["result"] = "Mật khẩu không khớp";
                return View();
            }

        }
    }
}
