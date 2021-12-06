using Microsoft.AspNetCore.Mvc;
using PJC.Models;

namespace PJC.Areas.User.Controllers
{
    [Area("User")]

    public class DocGiaController : Controller
    {
        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            return View(context.GetDocGia());
        }
        [HttpGet]
       // [Area("User")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
       // [Area("User")]
        public IActionResult Create(DocGia dg)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.CreateDocGia(dg);
            if (count > 0)
            {
                TempData["result"] = "Thêm mới độc giả thành công";
            }
            else
            {
                TempData["result"] = "Thêm mới độc giả không thành công";
            }
            return Redirect("~/User/DocGia/Index");
        }
        [HttpGet]
      //  [Area("User")]
        public IActionResult Edit(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            DocGia dg = context.GetDocGiaByMaDG(id);
            ViewData.Model = dg;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(DocGia dg)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.UpdateDocGia(dg);
            if (count > 0)
            {
                TempData["result"] = "Cập nhật thành công";
                return Redirect("~/User/DocGia/Index");
            }
            else
            {
                TempData["result"] = "Cập nhật không thành công";
                return Redirect("~/User/DocGia/Index");
            }
        }
        [HttpGet]
       // [Area("User")]
        public IActionResult Delete(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            DocGia dg = context.GetDocGiaByMaDG(id);
            ViewData.Model = dg;
            return View();
        }
        [HttpPost]
      //  [Area("User")]
        public IActionResult Delete(DocGia dg)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.DeleteDocGia(dg);
            if (count > 0)
            {
                TempData["result"] = "Xóa độc giả  thành công";
                return Redirect("~/User/DocGia/Index");
            }
            else
            {
                TempData["result"] = "Xóa độc giả không thành công";
                return Redirect("~/User/DocGia/Index");
            }
        }
       // [Area("User")]
        public IActionResult Detail(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            DocGia s = context.GetDocGiaByMaDG(id);
            ViewData.Model = s;
            return View();
        }
    }
}
