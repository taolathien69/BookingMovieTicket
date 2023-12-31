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
    public class VesController : BaseController
    {
        private DBcontext db = new DBcontext();

        // GET: Admin/Ves
        public ActionResult Index()
        {
            var ves = db.Ves.Include(v => v.LichChieu).Include(v => v.RapPhim).Include(v => v.TaiKhoan);
            ves = ves.OrderByDescending(v => v.NgayDat);
            return View(ves.ToList());
        }

        // GET: Admin/Ves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vee ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            return View(ve);
        }

        // GET: Admin/Ves/Create
        public ActionResult Create()
        {
            ViewBag.Id_LichChieu = new SelectList(db.LichChieux, "Id", "GioBatDau");
            ViewBag.IdRap = new SelectList(db.RapPhims, "Id", "TenRapChieu");
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "Id", "TenDangNhap");
            return View();
        }

        // POST: Admin/Ves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdTaiKhoan,IdRap,NgayDat,GiaVe,Id_LichChieu,Soluong")] Vee ve)
        {
            if (ModelState.IsValid)
            {
                db.Ves.Add(ve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_LichChieu = new SelectList(db.LichChieux, "Id", "GioBatDau", ve.Id_LichChieu);
            ViewBag.IdRap = new SelectList(db.RapPhims, "Id", "TenRapChieu", ve.IdRap);
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "Id", "TenDangNhap", ve.IdTaiKhoan);
            return View(ve);
        }

        // GET: Admin/Ves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vee ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_LichChieu = new SelectList(db.LichChieux, "Id", "GioBatDau", ve.Id_LichChieu);
            ViewBag.IdRap = new SelectList(db.RapPhims, "Id", "TenRapChieu", ve.IdRap);
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "Id", "TenDangNhap", ve.IdTaiKhoan);
            return View(ve);
        }

        // POST: Admin/Ves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdTaiKhoan,IdRap,NgayDat,GiaVe,Id_LichChieu,Soluong")] Vee ve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_LichChieu = new SelectList(db.LichChieux, "Id", "GioBatDau", ve.Id_LichChieu);
            ViewBag.IdRap = new SelectList(db.RapPhims, "Id", "TenRapChieu", ve.IdRap);
            ViewBag.IdTaiKhoan = new SelectList(db.TaiKhoans, "Id", "TenDangNhap", ve.IdTaiKhoan);
            return View(ve);
        }

        // GET: Admin/Ves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vee ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            return View(ve);
        }

        // POST: Admin/Ves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vee ve = db.Ves.Find(id);

            if (ve != null)
            {
                // Remove associated Ghe records
                var ghes = db.Ghes.Where(g => g.Id_Ve == id);
                db.Ghes.RemoveRange(ghes);

                db.Ves.Remove(ve);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
