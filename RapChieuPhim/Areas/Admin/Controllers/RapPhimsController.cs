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
    public class RapPhimsController : BaseController
    {
        private DBcontext db = new DBcontext();

        // GET: Admin/RapPhims
        public ActionResult Index()
        {
            return View(db.RapPhims.ToList());
        }
        [HttpPost]
        public JsonResult GetJsonResult()
        {
            List<RapPhimm> rapPhims = db.RapPhims.ToList();
            var jsonRap = rapPhims.Select(P => new
            {
                MaP = P.Id,
                TenRap = P.TenRapChieu,
                Soluong = P.TongSoPhong,
                ThanhPho = P.ThanhPho,
                QuanHuyen = P.QuanHuyen,
                TongSoPhong = P.TongSoPhong,
                TX = P.PhuongXa,
                KhungGio = P.KhungGio,


            }); ;
            return Json(jsonRap, behavior: JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/Phongs/Details/5
        // GET: Admin/RapPhims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RapPhimm rapPhim = db.RapPhims.Find(id);
            if (rapPhim == null)
            {
                return HttpNotFound();
            }
            return View(rapPhim);
        }

        // GET: Admin/RapPhims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RapPhims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenRapChieu,TongSoPhong,ThanhPho,QuanHuyen,PhuongXa,KhungGio")] RapPhimm rapPhim)
        {
            if (ModelState.IsValid)
            {
                db.RapPhims.Add(rapPhim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rapPhim);
        }

        // GET: Admin/RapPhims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RapPhimm rapPhim = db.RapPhims.Find(id);
            if (rapPhim == null)
            {
                return HttpNotFound();
            }
            return View(rapPhim);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenRapChieu,TongSoPhong,ThanhPho,QuanHuyen,PhuongXa,KhungGio")] RapPhimm rapPhim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rapPhim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rapPhim);
        }

        // GET: Admin/RapPhims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RapPhimm rapPhim = db.RapPhims.Find(id);
            if (rapPhim == null)
            {
                return HttpNotFound();
            }
            db.RapPhims.Remove(rapPhim);
            db.SaveChanges();
            return View(rapPhim);
        }

        // POST: Admin/RapPhims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RapPhimm rapPhim = db.RapPhims.Find(id);
            db.RapPhims.Remove(rapPhim);
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
