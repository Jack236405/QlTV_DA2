using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PJC.Models;
using Renci.SshNet.Messages;
using PJC.Controllers;
using Microsoft.AspNetCore.Authorization;
using PJC.Libs;

namespace PJC.Controllers
{
   // [Authorize]
    public class UserController : Controller
    {
        
        private StoreContext context;


        void setDBContext()
        {
            if (context == null)
                context = HttpContext.RequestServices.GetService(typeof(StoreContext)) as StoreContext;
        }
        public IActionResult Index(string Keyword)
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            return View(context.GetTaiKhoan());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(TaiKhoan tk)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.CreateNguoiDung(tk);
            if (count > 0)
            {
                TempData["result"] = "Thêm mới người dùng thành công";            
            }
            else
            {
                TempData["result"] = "Thêm mới người dùng không thành công";              
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            TaiKhoan tk = context.GetTaiKhoanByNguoiDung(id);
            ViewData.Model = tk;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(TaiKhoan tk)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.UpdateNguoiDung(tk);
            if (count > 0)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["result"] = "Cập nhật không thành công";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            TaiKhoan tk = context.GetTaiKhoanByNguoiDung(id);
            ViewData.Model = tk;
            return View();
        }
        [HttpPost]
        public IActionResult Delete(TaiKhoan tk)
        {

            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.DeleteNguoiDung(tk);
          
            if (count > 0)
            {
                TempData["result"] = "Xóa người dùng thành công";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["result"] = "Xóa người dùng không thành công";
                //return View();
                return RedirectToAction(nameof(Index));
            }
        }
    
    }
}
