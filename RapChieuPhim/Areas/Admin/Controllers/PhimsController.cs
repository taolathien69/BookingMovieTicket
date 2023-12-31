using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RapChieuPhim.Models;

namespace RapChieuPhim.Areas.Admin.Controllers
{
    public class PhimsController : BaseController
    {
        private DBcontext db = new DBcontext();

        // GET: Admin/Phims
        public ActionResult Index()
        {
            var phims = db.Phims.Include(p => p.LoaiPhim);
            return View(phims.ToList());
        }
        [HttpPost]
        public JsonResult GetJsonResult()
        {
            List<Phimm> phims = db.Phims.Include(p => p.LoaiPhim).ToList();
            var jsonPhims = phims.Select(P => new
            {
                MaP = P.Id,
                TenP = P.TenPhim,
                AnhPhim = P.AnhPhim,
                MoTa = P.MoTa,
                LoaiPhim = P.LoaiPhim.TenLoai,
                ThoiLuong = P.ThoiLuong,
                NgayCongChieu = P.NgayCongChieu,
                NgayKetThuc = P.NgayKetThuc,
                DaoDien = P.DaoDien,
                TrangThai = P.TinhTrang,
            });
            return Json(jsonPhims, behavior: JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/Phims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phimm phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            return View(phim);
        }

        // GET: Admin/Phims/Create
        public ActionResult Create()
        {
            ViewBag.IdLoaiPhim = new SelectList(db.LoaiPhims, "Id", "TenLoai");
            return View();
        }

        // POST: Admin/Phims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenPhim,AnhPhim,ThoiLuong,MoTa,TinhTrang,IdLoaiPhim,DienVien,DaoDien,NgayCongChieu,NgayKetThuc,NamPhatHanh,ChatLuong")] Phimm phim)
        {
            HttpPostedFileBase upload = Request.Files["val-file"];

            if (upload != null && upload.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(upload.FileName);
                string _path = Path.Combine(Server.MapPath("~/Content/Upload/Image"), _FileName);
                upload.SaveAs(_path);
            }
            if (ModelState.IsValid)
            {
                phim.AnhPhim = Path.GetFileName(upload.FileName);
                db.Phims.Add(phim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.IdLoaiPhim = new SelectList(db.LoaiPhims, "Id", "TenLoai", phim.IdLoaiPhim);
            return View(phim);
        }

        // GET: Admin/Phims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phimm phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLoaiPhim = new SelectList(db.LoaiPhims, "Id", "TenLoai", phim.IdLoaiPhim);
            return View(phim);
        }

        // POST: Admin/Phims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenPhim,AnhPhim,ThoiLuong,MoTa,TinhTrang,IdLoaiPhim,DienVien,DaoDien,NgayCongChieu,NgayKetThuc,NamPhatHanh,ChatLuong")] Phimm phim)
        {
            HttpPostedFileBase upload = Request.Files["val-file"];

            if (upload != null && upload.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(upload.FileName);
                string _path = Path.Combine(Server.MapPath("~/Content/Upload/Image"), _FileName);
                upload.SaveAs(_path);
            }
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    phim.AnhPhim = Path.GetFileName(upload.FileName);
                }

                db.Entry(phim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLoaiPhim = new SelectList(db.LoaiPhims, "Id", "TenLoai", phim.IdLoaiPhim);
            return View(phim);
        }

        // GET: Admin/Phims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phimm phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            db.Phims.Remove(phim);
            db.SaveChanges();
            return View(phim);
        }

        // POST: Admin/Phims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phimm phim = db.Phims.Find(id);
            db.Phims.Remove(phim);
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
