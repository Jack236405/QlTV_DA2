using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using PJC.Libs;
using PJC.Models;
using Renci.SshNet;

namespace PJC.Controllers
{
   

    public class LoginController : Controller
    {
        const string SessionQuyen = "_Quyen";

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View();
        }
     
        [HttpPost]
        public IActionResult Index(string NguoiDung,string MatKhau)
        {
            string matKhauMaHoa = SHA1.ComputeHash(MatKhau);

     
                StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
                int kq = context.Login(NguoiDung, matKhauMaHoa);
                TempData["NguoiDunglogin"] = NguoiDung;
                HttpContext.Session.SetString("NguoiDung", NguoiDung);          
                if (kq == 1)
                {

                    return RedirectToAction("Index", "Home");
                    //return RedirectToAction("Index", "Home");
                }
                else if (kq == -1)
                {
                    TempData["result"] = "Đăng nhập không thành công";
                    return RedirectToAction("Index", "Login");
                }
                return Redirect("~/User/Home/Index");
                }
        
     
    }
}
