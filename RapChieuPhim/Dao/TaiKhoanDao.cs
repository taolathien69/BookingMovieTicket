using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RapChieuPhim.Models;
using RapChieuPhim.ViewModel;

namespace RapChieuPhim.Dao
{
    public class TaiKhoanDao
    {
        private DBcontext db = new DBcontext();
        public TaiKhoann checkTaikhoan(string username, string password)
        {



            TaiKhoann checkTK = db.TaiKhoans.Include(t => t.ThongTin).FirstOrDefault(acc => acc.TenDangNhap == username && acc.MatKhau == password);
            return checkTK;

        }

        public bool IsEmailExists(string email)
        {
            return db.TaiKhoans.Any(acc => acc.TenDangNhap == email);
        }

        public TaiKhoann SaveTaiKhoan(TaiKhoann taiKhoan)
        {
            db.TaiKhoans.Add(taiKhoan);
            db.SaveChanges();
            return null;
        }
    }
}