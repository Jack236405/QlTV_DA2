using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PJC.Models;

namespace PJC.Areas.User.Controllers
{
    //[Authorize]
    [Area("User")]
    public class PhieuTraController : Controller
    {
        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            return View(context.GetPhieuTra());
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            ViewBag.mapm = HttpContext.Session.GetString("mapm");
            ViewData["MaSach"] = new SelectList(context.GetSanPham(), "MaSach", "TenSach");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CTPM pt)
        {
            int count;
           
            ViewBag.mapm = HttpContext.Session.GetString("mapm");
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.CreatePhieuTra(pt);
            if (count > 0)
            {
                TempData["result"] = "Thêm sách thành công";
            }
            else
            {
                TempData["result"] = "Thêm sách thành công";
            }
            return Redirect("~/User/PhieuTra/Create");
        }  
        [HttpGet]
        public IActionResult Edit(string id,string mas)
        {
            ViewBag.sessionv = HttpContext.Session.GetString("NguoiDung");
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            CTPM pt = context.GetPhieuTraByMaPM(id,mas);
            ViewData.Model = pt;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(PhieuMuonInCTPM pt)
        {
            int count;
            ViewBag.sessionv = HttpContext.Session.GetString("NguoiDung");
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.UpdatePhieuTra(pt);
            if (count > 0)
            {
                TempData["result"] = "Cập nhật thành công";
                return Redirect("~/User/PhieuTra/Index");
            } 
            else
            {
                TempData["result"] = "Cập nhật không thành công";
                return Redirect("~/User/PhieuTra/Index");
            }
        }
        [HttpGet]
        public IActionResult Delete(string id,string mas)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            CTPM pt = context.GetPhieuTraByMaPM(id,mas);
             ViewData.Model = pt;
            return View();
        }
        [HttpPost]
        public IActionResult Delete(CTPM pt)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.DeletePhieuTra(pt);
            if (count > 0)
            {
                TempData["result"] = "Xóa thành công";
                return Redirect("~/User/PhieuTra/Index");
            }
            else
            {
                TempData["result"] = "Xóa không thành công";
                return Redirect("~/User/PhieuTra/Index");
            }
        }
        [HttpGet]
        public IActionResult Detail(string id,string mas)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            CTPM pt = context.GetPhieuTraByMaPM(id,mas);
           ViewData.Model = pt;
            return View();
        }
        public IActionResult TraSach()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            return View(context.GetPhieuChuaTra());
        }
        [HttpGet]
        public IActionResult EditTraSach(string id, string mas)
        {
            ViewBag.sessionv = HttpContext.Session.GetString("NguoiDung");
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            PhieuMuonInCTPM pt = context.GetPhieuChuaTraById(id, mas);
            ViewData.Model = pt;
            return View();
        }
        [HttpPost]
        public IActionResult EditTraSach(PhieuMuonInCTPM pt)
        {
            int count, count1;
            ViewBag.sessionv = HttpContext.Session.GetString("NguoiDung");
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.UpdatePhieuTra(pt);
            count1 = context.UpdateTienPhat(pt);
            DateTime ngaytra = pt.NgayTra ?? DateTime.Now; ;
            DateTime ngayhentra = pt.NgayHenTra;
            TimeSpan Time = ngaytra - ngayhentra;
            int day = Time.Days;
            int? hieu = pt.TinhTrangSach - pt.TinhTrangTra;
            double? tienphat = 0;
            if (hieu > 0 && day > 0)
            {
                tienphat = hieu * 10000 + day * 5000;
                TempData["result"] = "Bạn làm hao tổn sách: " + hieu + "%. Và bạn trễ hạn: " + day + " ngày. Bạn bị phạt: " + (hieu * 10000 + day * 5000);
            }
            if (hieu > 0 && day <= 0)
            {
                tienphat = hieu * 10000;
                TempData["result"] = "Bạn làm hao tổn sách: " + hieu + "%. Bạn bị phạt: " + hieu * 10000 + " VND";
            }
            if (hieu == 0 && day > 0)
            {
                tienphat = day * 5000;
                TempData["result"] = "Bạn trễ hạn " + day + " ngày. Bạn bị phạt: " + day * 5000;
            }
            if (pt.TinhTrangTra == 0)
            {
                Sach s = context.GetSachByMa(pt.MaSach);
                tienphat = s.GiaTien;
                TempData["result"] = "Bạn làm mất sách.Tiền Sách: " + tienphat;
            }
            if (hieu == 0 && day <= 0)
            {
                TempData["result"] = "Trả sách thành công";
            }
            return Redirect("~/User/PhieuTra/Index");

        }
    }
}
