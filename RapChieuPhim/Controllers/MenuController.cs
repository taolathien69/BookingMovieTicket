using RapChieuPhim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RapChieuPhim.Controllers
{
    public class MenuController : Controller
    {
        private DBcontext db = new DBcontext();
        // GET: Menu
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var data = db.LoaiPhims.ToList();
            return PartialView(data);
        }

        public ActionResult Theloai(int id)
        {
            // Lấy danh sách phim theo id thể loại từ cơ sở dữ liệu
            var phims = db.Phims.Where(p => p.IdLoaiPhim == id).ToList();

            // Truyền danh sách phim vào view
            return View(phims);
        }

    }
}