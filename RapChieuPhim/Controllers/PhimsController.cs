using RapChieuPhim.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using RapChieuPhim.Models;
using RapChieuPhim.ViewModel;
using System.Net;

namespace RapChieuPhim.Controllers
{
    public class PhimsController : Controller
    {
        // GET: Phims
        private DBcontext db = new DBcontext();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index(string category, String searchString = "", string[] genre = null)
        {
            var dao = new PhimDao();
            List<Phimm> model = (List<Phimm>)dao.GetPhims();

            // Lọc theo thể loại
            switch (category)
            {
                case "NowShowing":
                    model = model.Where(m => m.NgayCongChieu <= DateTime.Now).ToList();
                    break;
                case "Upcoming":
                    model = model.Where(m => m.NgayCongChieu > DateTime.Now).ToList();
                    break;
            }

            // Tiếp tục lọc theo searchString và genre nếu có
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(m => m.TenPhim.ToLower().Contains(searchString.ToLower())).ToList();
            }

            if (genre != null && genre.Length > 0)
            {
                model = model.Where(m => genre.Contains(m.IdLoaiPhim.ToString())).ToList();
            }

            ViewData["pagelist"] = model;
            return View();
        }

        public ActionResult DetatilPhims(int? id)
        {

            var dao = new PhimDao();
            var binhLuan = dao.GetBinhLuansForPhim(Convert.ToInt32(id));
            int reviewScore = 0;
            for (int i = 0; i < binhLuan.Count; i++)
            {
                reviewScore += binhLuan[i].DanhGia;
            }
            ViewData["reviewScore"] = 1.0f * reviewScore / binhLuan.Count;
            ViewData["reviewQuantity"] = binhLuan.Count;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var phims = dao.getPhimFindbyId(id);

            if (phims == null)
            {
                return HttpNotFound();
            }


            phims.BinhLuans = dao.GetBinhLuansForPhim(id.Value);

            ViewData["phimview"] = phims;
            Session.Add("PHIM", phims);

            return View(phims); // Truyền đối tượng phims vào view
        }


        [HttpPost]
        public ActionResult AddComment(int IdPhim, string NoiDungBinhLuan, int? DanhGiaSao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var binhLuan = new RapChieuPhim.Models.BinhLuann
                    {
                        IdPhim = IdPhim,
                        NoiDung = NoiDungBinhLuan,
                        DanhGia = DanhGiaSao ?? 0, // Sử dụng giá trị mặc định nếu DanhGiaSao là null
                        NgayDang = DateTime.Now,
                        // Khởi tạo các trường khác
                    };

                    db.BinhLuans.Add(binhLuan);
                    db.SaveChanges();

                    return RedirectToAction("DetatilPhims", new { id = IdPhim });
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.WriteLine(ex.Message);
                    // Return an error view if necessary
                }
            }

            return RedirectToAction("DetatilPhims", new { id = IdPhim });
        }

    }
}
