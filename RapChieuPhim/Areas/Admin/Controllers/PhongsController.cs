using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RapChieuPhim.Models;

namespace RapChieuPhim.Areas.Admin.Controllers
{
    public class PhongsController : BaseController
    {
        private DBcontext db = new DBcontext();

        // GET: Admin/Phongs
        public ActionResult Index()
        {
            var phongs = db.Phongs.Include(p => p.RapPhim);
            return View(phongs.ToList());
        }
        // POST: Admin/Phongs/GetJsonResult
        [HttpPost]
        public JsonResult GetJsonResult()
        {
            List<Phongg> phongs = db.Phongs.Include(p => p.RapPhim).ToList();
            var jsonPhong = phongs.Select(P => new
            {
                MaP = P.Id,
                TenP = P.TenPhong,
                Soluong = P.SoLuong,
                Mota = P.MoTa,
                TenRap = P.RapPhim.TenRapChieu,
                TrangThai = P.TrinhTrang,
            }); ;
            return Json(jsonPhong, behavior: JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/Phongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phongg phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        // GET: Admin/Phongs/Create
        public ActionResult Create()
        {
            ViewBag.IdRapChieu = new SelectList(db.RapPhims, "Id", "TenRapChieu");
            return View();
        }

        // POST: Admin/Phongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdRapChieu,TenPhong,SoLuong,TrinhTrang,MoTa")] Phongg phong)
        {
            if (ModelState.IsValid)
            {
                db.Phongs.Add(phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRapChieu = new SelectList(db.RapPhims, "Id", "TenRapChieu", phong.IdRapChieu);
            return View(phong);
        }

        // GET: Admin/Phongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phongg phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRapChieu = new SelectList(db.RapPhims, "Id", "TenRapChieu", phong.IdRapChieu);
            return View(phong);
        }

        // POST: Admin/Phongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdRapChieu,TenPhong,SoLuong,TrinhTrang,MoTa")] Phongg phong) 
        {
            if (ModelState.IsValid)
            {
                db.Entry(phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRapChieu = new SelectList(db.RapPhims, "Id", "TenRapChieu", phong.IdRapChieu);
            return View(phong);
        }


        // GET: Admin/Phongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phongg phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        // POST: Admin/Phongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phongg phong = db.Phongs.Find(id);
            db.Phongs.Remove(phong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
